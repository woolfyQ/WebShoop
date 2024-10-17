using Application.Service;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebShop.API.Controller
{
    [ApiController]
    [Route("Order")]
    [Authorize]
    public class OrderController : ControllerBase
    {


        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _orderService.Create(orderDTO);
            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _orderService.AddProduct(orderDTO);
            return Ok(cart);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id, [FromBody] OrderDTO orderDTO)
        {
            var cart = await _orderService.Delete(id, orderDTO);
            return Ok(cart);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart(Guid id)
        {
            var cart = await _orderService.GetByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
    }



}




