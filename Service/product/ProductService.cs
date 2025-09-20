using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Service.product
{
    public class ProductService : IProductService
    {
        private readonly UserDBContext _dbContext;

        public ProductService(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy danh sách tất cả sản phẩm
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        // Lấy sản phẩm theo ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        // Thêm sản phẩm mới
        public async Task<bool> AddProductAsync(Product newProduct)
        {
            try
            {
                await _dbContext.Products.AddAsync(newProduct);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật sản phẩm
        public async Task<bool> UpdateProductAsync(Product updatedProduct)
        {
            try
            {
                var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);
                if (existingProduct == null) return false;

                // Cập nhật thông tin sản phẩm
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Description = updatedProduct.Description;

                _dbContext.Products.Update(existingProduct);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa sản phẩm
        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var productToDelete = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (productToDelete == null) return false;

                _dbContext.Products.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetNewProductsAsync()
        {
            return await _dbContext.Products.OrderByDescending(p => p.Id).Take(3).ToListAsync();

        }
    }
}
