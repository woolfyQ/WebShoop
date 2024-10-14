using Application.Service;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.API.Controller
{

    [ApiController]
    [Route("Auth")]
    public class AuthController: ControllerBase
    {

        private readonly UserService _userService;
        private readonly TokenProvider _tokenProvider;
       
       public AuthController (UserService userService, TokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
            _userService = userService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SigIn(UserDTO userDTO)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.ValidateUser(userDTO.Email, userDTO.Password);
            if (user.Email == null)
            {
                return Unauthorized("Invalid password or Email");
            }
            var token = _tokenProvider.Create(user);
            return Ok(new { Token = token });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var AllreadyUser = await _userService.ValidateUser(userDTO.Email, userDTO.Password);

            if(AllreadyUser != null)
            {
                return Conflict("User was created before");
            }
            var user = await _userService.Create(userDTO);
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);

        }

    }
}
