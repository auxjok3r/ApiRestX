using ApiRestX.Dtos;
using ApiRestX.Models;
using ApiRestX.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ApiRestX.Services
{
    public class ProductService : IProductService
    {
        private readonly InMemoryDbContext _context;

        public ProductService(InMemoryDbContext context) {
            _context = context;
        }

        public async Task createProduct(ProductDto product)
        {
            var newProduct = new Product();
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;   
            newProduct.Mrp = product.Mrp;
            newProduct.Stock = product.Stock;
            _context.Product.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> getProducts()
        {
           return await _context.Product.OrderBy(x => x.Price).ToListAsync();
        }

        public async Task<List<string>> updateProduct(int idProducto)
        {
            List<string> mensajes = new List<string>();
            var product = await _context.Product.FindAsync(idProducto);
            if (product != null)
            {
                if (product.Mrp <= product.Price) {
                    mensajes.Add("MRP debe ser mayor o igual al precio");
                }
                if (product.Stock <= 0) {
                    mensajes.Add("El recuento de existencias es 0");
                }

                if (mensajes.Count == 0) {
                    product.IsPublished = true;
                    _context.Product.Update(product);
                    await _context.SaveChangesAsync();
                }
                return mensajes;
            }
            else {
                throw new Exception("No existe en producto a actualizar");
            }
        }
    }
}
