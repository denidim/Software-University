using SharedTrip.Models;
using SharedTrip.Models.Users;
using System.Collections.Generic;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        void RegisterUser(RegisterViewModel model);
        (bool isvalid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);
    }
}
