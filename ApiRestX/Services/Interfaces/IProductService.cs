using ApiRestX.Dtos;
using ApiRestX.Models;

namespace ApiRestX.Services.Interfaces
{
    public interface IProductService
    {
        public Task createProduct(ProductDto product);

        public Task<List<string>> updateProduct(int idProducto);

        public Task<List<Product>> getProducts(); 
    }
}
