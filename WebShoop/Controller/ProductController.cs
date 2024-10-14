using Application.Service;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.API.Controller
{

    [Route("Product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;

        }

        public async Task<IActionResult> Create([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.Create(productDTO);
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var product = await _productService.GetByIdAsync(Id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedProduct = await _productService.Update(id, productDTO);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deletedProduct = await _productService.Delete(id);
                return Ok(deletedProduct);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
