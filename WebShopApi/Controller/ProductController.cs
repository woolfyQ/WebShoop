using Application.Service;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;


namespace WebShop.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController(ProductService productService) : ControllerBase
    {


    }
       
}
