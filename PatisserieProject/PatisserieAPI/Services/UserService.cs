using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;
using PatisserieAPI.Options;
using PatisserieAPI.ViewModels;
using Twilio;
using Twilio.Rest.Chat.V2;
using Twilio.Rest.Lookups.V2;
using Twilio.Rest.Verify.V2.Service;

namespace PatisserieAPI.Services
{
    public class UserService : IUserService
    {
        private readonly TwilioOptions _twilioOptions;
        public UserService(
            IOptions<TwilioOptions> twilioOptions)
        {
            EnsureArg.IsNotNull(twilioOptions, nameof(twilioOptions));
            _twilioOptions = twilioOptions.Value;
        }
        
        
        public bool SendVerificationCode(PhoneNumberViewModel phoneNumber)
        {
            try
            {
                if (phoneNumber.PhoneNumber.StartsWith("0"))
                {
                    phoneNumber.PhoneNumber = "+44" + phoneNumber.PhoneNumber.Remove(0, 1);
                }
                else
                {
                    phoneNumber.PhoneNumber = "+44" + phoneNumber.PhoneNumber;
                }
                TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthenticationToken);
                if (ValidatePhoneNumber(phoneNumber.PhoneNumber))
                {
                    var options = new CreateVerificationOptions(pathServiceSid: _twilioOptions.VerificationSid, to: phoneNumber.PhoneNumber, channel: CallOrSms(phoneNumber.PhoneNumber));
                    VerificationResource.Create(options);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool VerifyVerificationCode(VerifyViewModel verifyData)
        {
            TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthenticationToken);
            var options = new CreateVerificationCheckOptions(pathServiceSid: _twilioOptions.VerificationSid);
            options.Code = verifyData.VerificationCode;
            if (verifyData.PhoneNumber.StartsWith("0"))
            {
                verifyData.PhoneNumber = "+44" + verifyData.PhoneNumber.Remove(0, 1);
            }
            else
            {
                verifyData.PhoneNumber = "+44" + verifyData.PhoneNumber;
            }
            options.To = verifyData.PhoneNumber;
            var verificationCheck = VerificationCheckResource.Create(options);
            
            return (verificationCheck == null || verificationCheck.Valid == null) ? false : (bool)(verificationCheck.Valid);
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {         
            var options = new FetchPhoneNumberOptions(phoneNumber);
            var phoneNumberValidated = PhoneNumberResource.Fetch(options);

            return phoneNumberValidated.CountryCode != null && phoneNumberValidated.CountryCode != "GB" ? 
                throw new Exception ("Phone number is not a UK number"):
                phoneNumberValidated.Valid?? false;
        }
        
        private string CallOrSms(string phoneNumber)
        {
            var type = new List<string> { "carrier" };
            var phoneNumberType = Twilio.Rest.Lookups.V1.PhoneNumberResource.Fetch(type: type, pathPhoneNumber: new Twilio.Types.PhoneNumber(phoneNumber));
            var carrierJson = JsonConvert.SerializeObject(phoneNumberType.Carrier);
            var carrier = JsonConvert.DeserializeObject<Dictionary<string,string>>(carrierJson);

            return carrier?["type"] == "landline" ? "call" : "sms";
        }
    }
}
