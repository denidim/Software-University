using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Services
{
    /// <summary>
    /// Manipulate product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        private readonly IConfiguration config;

        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(IConfiguration _config, IRepository _repo)
        {
            config = _config;
            repo = _repo;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">product model</param>
        /// <returns></returns>
        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await repo.All<Product>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if(product != null)
            {
                product.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await repo.AllReadonly<Product>()
                .Where(p=>p.IsActive)
                .Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToListAsync();
        }

        public async Task<ProductDto> GetForEditAsync(Guid id)
        {
            var product =  await repo.GetByIdAsync<Product>(id);

            var productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };

            return productDto;
        }

        public async Task EditAsync(ProductDto model)
        {
            var entity = await repo.GetByIdAsync<Product>(model.Id);

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Quantity = model.Quantity;

            await repo.SaveChangesAsync();
        }
    }
}
