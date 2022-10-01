using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;
        private readonly IValidationService validationService;

        public ProductService(IRepository _repository, IValidationService _validationService)
        {
            repository = _repository;
            validationService = _validationService;
        }

        public (bool created, string error) Create(CreateViewModel model)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModle(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            decimal price = 0;

            if(!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < 0.05M || price > 1000M)
            {
                return (false, "Price must be between 0.05 and 1000");
            }

            var product = new Product
            {
                Name = model.Name,
                Price = price,
            };

            try
            {
                repository.Add(product);
                repository.SaveChanges();
                created = true;
            }
            catch (System.Exception)
            {
                error = "Could not save product";
            }

            return (created, error);
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repository.All<Product>()
                .Select(x => new ProductListViewModel()
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("f2"),
                    ProductId = x.Id
                })
                .ToList();
        }
    }
}
