using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Service.product;
using API.Models;
using API.Dtos;


namespace API.Controllers.LoadProduct

{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/v1/product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProductsAsync();
            Console.WriteLine($"Products count: {products.Count()}");
            return Ok(products.ToList());
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchProductRequest request)
        {
            var result = await _productService.SearchProductsAsync(request);
            return Ok(result);
        }


        // GET: api/v1/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound("Product not found.");
            return Ok(product);
        }

        // POST: api/v1/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product newProduct)
        {
            // Validate input data
            if (newProduct == null)
                return BadRequest("Invalid product data.");

            var result = await _productService.AddProductAsync(newProduct);
            if (result)
                return Ok("Product added successfully.");
            return BadRequest("Failed to add product.");
        }

        // PUT: api/v1/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Id)
                return BadRequest("Product ID mismatch.");

            var result = await _productService.UpdateProductAsync(updatedProduct);
            if (result)
                return Ok("Product updated successfully.");
            return BadRequest("Failed to update product.");
        }

        // DELETE: api/v1/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result)
                return Ok("Product deleted successfully.");
            return NotFound("Product not found.");
        }
        [HttpGet("new")]
        public async Task<IActionResult> GetNewProducts()
        {
            var products = await _productService.GetNewProductsAsync();
            if (products == null)
                return NotFound("No new product found.");
            return Ok(products.ToList());
        }
    }
}
