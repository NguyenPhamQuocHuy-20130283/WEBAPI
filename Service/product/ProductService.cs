using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
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

        public async Task<SearchProductResponse> SearchProductsAsync(SearchProductRequest request)
        {
            var query = _dbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(p => p.Name.Contains(request.Keyword) || p.Description.Contains(request.Keyword));

            if (request.MinPrice.HasValue)
                query = query.Where(p => p.Price >= request.MinPrice.Value);

            if (request.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= request.MaxPrice.Value);

            var totalItems = await query.CountAsync();

            var products = await query
                .OrderBy(p => p.Id)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description
                })
                .ToListAsync();

            return new SearchProductResponse
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize),
                Data = products
            };
        }


    }
}
