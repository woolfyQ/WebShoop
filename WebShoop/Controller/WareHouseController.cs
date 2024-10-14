using Application.Service;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebShop.API.Controller
{
    [ApiController]
    [Route("Order")]
    [Authorize]
    public class WareHouseController : ControllerBase
    {


        private readonly WareHouseService _wareHouseService;

        public WareHouseController(WareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] WareHouseDTO wareHouseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var warehouse = await _wareHouseService.Create(wareHouseDTO);
            return Ok(warehouse);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] WareHouseDTO wareHouseDTO, int amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var warehouse = await _wareHouseService.AddProduct(wareHouseDTO, amount);
            return Ok(warehouse);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var warehouse = await _wareHouseService.Delete(id);
            return Ok(warehouse);
        }


     
    }



}




