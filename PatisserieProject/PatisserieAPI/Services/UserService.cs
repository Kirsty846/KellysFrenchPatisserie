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
        
        
        public async Task<string> SendVerificationCode(string phoneNumber)
        {
            TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthenticationToken);
            var service = ServiceResource.Create(friendlyName: "Kelly's Patisserie");
            if (ValidatePhoneNumber(phoneNumber))
            {
                var options = new CreateVerificationOptions(pathServiceSid: service.Sid, to: phoneNumber, channel: CallOrSms(phoneNumber));
                VerificationResource.Create(options);
            }
            return service.Sid;
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
