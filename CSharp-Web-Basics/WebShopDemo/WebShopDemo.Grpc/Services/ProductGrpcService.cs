using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WebShopDemo.Core.Contracts;

namespace WebShopDemo.Grpc.Services
{
    public class ProductGrpcService : Product.ProductBase
    {
        private readonly IProductService service;

        public ProductGrpcService(IProductService productGrpcService)
        {
            service = productGrpcService;
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            ProductList result = new ProductList();
            var products = await service.GetAll();

            result.Items.AddRange(products.Select(p => new ProductItem()
            {
                Name = p.Name,
                Id = p.Id.ToString(),
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return result;
        }
    }
}
