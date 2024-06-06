using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }


    [HttpPost]
    public async Task<IActionResult> InsertProduct([FromBody] InsertDTO insertDto)
    {
        if (!await _productService.DoesCategoryExist(insertDto))
        {
            return BadRequest("One of given Categories does not exist");
        }
        
        await _productService.InsertProduct(insertDto);
        return Ok("Given product has been added");

    }
    
    
    
}