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
    }
}
