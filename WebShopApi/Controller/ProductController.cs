using Core.DTO;
using Microsoft.AspNetCore.Mvc;


namespace WebShop.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IController _productRepository;
        public ProductController(IController productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()  
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid Id)
        {
            var product = await _productRepository.GetByIdAsync(Id);
            return Ok(product);
        }

        [HttpPost]
        public async Task <ActionResult<ProductDTO>> Create (ProductDTO productDTO)
        {
            var product = await _productRepository.Create(productDTO);
            return CreatedAtAction(nameof(GetProduct), new {id = product.Id}, product);

        }
        [HttpPut("{id}")]
        public async Task <ActionResult<ProductDTO>> Update(Guid Id, ProductDTO productDTO)
        {
            try
            {
                await _productRepository.Update(Id, productDTO);
            }
            catch (Exception) 
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(Guid Id)
        {
            try
            {
                await _productRepository.DeleteByIdAsync(Id);
            }
            catch (Exception)
            {
                return NotFound();

            }
            return NoContent();
        }
    }
}
