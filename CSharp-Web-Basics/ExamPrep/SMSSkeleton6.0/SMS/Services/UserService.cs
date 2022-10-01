using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Models.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public UserService(IRepository _repository, IValidationService _validationService)
        {
            repo = _repository;
            validationService = _validationService;
        }

        public string GetUsername(string userId)
        {
            return repo.All<User>().FirstOrDefault(u => u.Id == userId)?.Username;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == Calculatehash(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }

        public (bool registrated, string error) Register(RegisterViewModel modlel)
        {
            bool registrated = false;
            string error = null;


            var (isValid, validateError) = validationService.ValidateModle(modlel);

            if (!isValid)
            {
                return (isValid, validateError);
            }
            
            Cart cart = new Cart();

            User user = new User()
            {
                Email = modlel.Email,
                Password = Calculatehash(modlel.Password),
                Username = modlel.Username,
                Cart = cart,
                CardId = cart.Id,
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registrated = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (registrated, error);
        }

       
        private string Calculatehash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            using(SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(bytes));
            }
        }

    }
 /*
 * Has an Id – a string, Primary Key 

Has a Username – a string with min length 5 and max length 20 (required) 

Has an Email – a string, which holds only valid email (required) 

Has a Password – a string with min length 6 and max length 20 - hashed in the database (required) 

Has a Cart – a Cart object (required) 
 */

}
