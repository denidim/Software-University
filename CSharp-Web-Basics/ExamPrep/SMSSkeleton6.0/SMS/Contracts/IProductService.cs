using SMS.Models;
using System.Collections;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool created,string error) Create(CreateViewModel model);

        IEnumerable<ProductListViewModel> GetProducts();
    }
}
