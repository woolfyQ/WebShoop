using Application.Service;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebShop.API.Controller
{
    [ApiController]
    [Route("Storage")]
    [Authorize]
    public class StorageController : ControllerBase
    {


        private readonly StorageService _storageService;

        public StorageController(StorageService wareHouseService)
        {
            _storageService = wareHouseService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductStorageDTO wareHouseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var warehouse = await _storageService.Create(wareHouseDTO);
            return Ok(warehouse);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductStorageDTO wareHouseDTO, int amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var warehouse = await _storageService.AddProduct(wareHouseDTO, amount);
            return Ok(warehouse);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var warehouse = await _storageService.Delete(Id);
            return Ok(warehouse);
        }


     
    }



}




