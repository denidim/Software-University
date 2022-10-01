using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repository;

        public CartService(IRepository _repository)
        {
            repository = _repository;
        }

        public IEnumerable<CartViewModel> AddProduct(string productId, string userId)
        {
            var user = repository.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            var product = repository.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            user.Cart.Products.Add(product);

            try
            {
                repository.SaveChanges();
            }
            catch (Exception)
            {}

            return user.Cart.Products
                .Select(p => new CartViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }

      

        public void BuyProduct(string userId)
        {
            var user = repository.All<User>()
                  .Where(u => u.Id == userId)
                  .Include(u => u.Cart)
                  .ThenInclude(c => c.Products)
                  .FirstOrDefault();

            user.Cart.Products.Clear();

            repository.SaveChanges();
        }

        public IEnumerable<CartViewModel> GetProducts(string userId)
        {
            var user = repository.All<User>()
                 .Where(u => u.Id == userId)
                 .Include(u => u.Cart)
                 .ThenInclude(c => c.Products)
                 .FirstOrDefault();

            return user.Cart.Products
               .Select(p => new CartViewModel()
               {
                   ProductName = p.Name,
                   ProductPrice = p.Price.ToString("F2")
               });
        }
    }
}
