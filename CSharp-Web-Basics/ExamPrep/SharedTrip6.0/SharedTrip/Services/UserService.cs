using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            this._repository = repository;
        }

        public void RegisterUser(RegisterViewModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Username = model.UserName
            };

            user.Password = HashPassword(model.Password);

            _repository.Add(user);
            _repository.SaveChanges();
        }

        private string HashPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sHA256 = SHA256.Create())
            {
                return Convert.ToBase64String(sHA256.ComputeHash(bytes));
            }
        }

        public (bool isvalid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if(model.UserName == null ||  model.UserName.Length < 5 || model.UserName.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username is requred and must be between 5 and 20 characters"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required"));
            }

            if(model.Password == null || model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is requred and must be between 6 and 20 characters"));
            }

            if(model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password adn ConfirmPassword are not the same"));
            }

            return (isValid, errors);
        }
    }
}
