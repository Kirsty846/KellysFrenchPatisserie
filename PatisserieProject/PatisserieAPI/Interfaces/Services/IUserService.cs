using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Interfaces
{
    public interface IUserService
    {
        Task<string> SendVerificationCode(string phoneNumber);

    }
}
