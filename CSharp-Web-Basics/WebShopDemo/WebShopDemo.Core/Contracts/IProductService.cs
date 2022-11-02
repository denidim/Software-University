using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Contracts
{
    /// <summary>
    /// Manipulate product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GetAll();

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">product model</param>
        /// <returns></returns>
        Task Add(ProductDto productDto);

        Task Delete(Guid id);

        Task<ProductDto> GetForEditAsync(Guid id);

        Task EditAsync(ProductDto model);
    }
}
