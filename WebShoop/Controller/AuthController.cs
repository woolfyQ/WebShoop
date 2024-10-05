using Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.API.Controller
{
    [ApiController]
    public class AuthController : ControllerBase
    {

     
        private readonly TokenProvider _tokenProvider;
       
       public AuthController (TokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }
       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var token = _tokenProvider.Create(userDTO);
            return Ok(new { Token = token });
        }
        
    }
}
