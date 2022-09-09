using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Interfaces
{
    public interface IUserService
    {
        bool SendVerificationCode(PhoneNumberViewModel phoneNumber);

        bool VerifyVerificationCode(VerifyViewModel verifyData);

    }
}
