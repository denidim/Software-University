using Microsoft.Win32;
using SMS.Models;

namespace SMS.Contracts
{
    public interface IUserService
    {
        (bool registrated, string error) Register(RegisterViewModel modlel);

        string Login(LoginViewModel model);

        string GetUsername(string userId);
    }
}
