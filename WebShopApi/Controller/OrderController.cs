
//using Core;
//using Core.DTO;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics.Metrics;

//namespace WebShop.API.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    public class OrderController : ControllerBase
//    {
//        private readonly IController _orderRepository;
//        public OrderController(IController orderRepository)
//        {
//            _orderRepository = orderRepository;
//        }
//        [HttpGet("{Id}")]
//        public async Task<ActionResult<ProductCartDTO>> GetByIdAsync(Guid Id)
//        {
//            var productCart = await _orderRepository.GetByIdAsync(Id);
//            return Ok(productCart);
//        }

//        public async Task<ActionResult<ProductCartDTO>> Create(ProductCartDTO productCartDTO)
//        {
//            var productCart = await _orderRepository.Create(productCartDTO);
//            return Ok(productCart);
//        }

        
//    }

//}
