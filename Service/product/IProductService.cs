using API.Models;

namespace API.Service.product

{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync(Product newProduct);
        Task<bool> UpdateProductAsync(Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetNewProductsAsync();
    }
}
