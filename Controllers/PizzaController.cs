using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PizzaController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public PizzaController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }


    [HttpGet("sizes")]
    // [Authorize]
    public IActionResult GetAllSizes()
    {
        return Ok(_dbContext.Sizes);
    }
    [HttpGet("cheeses")]
    // [Authorize]
    public IActionResult GetAllCheeses()
    {
        return Ok(_dbContext.Cheeses);
    }
    [HttpGet("sauces")]
    // [Authorize]
    public IActionResult GetAllSauces()
    {
        return Ok(_dbContext.Sauces);
    }
    [HttpGet("toppings")]
    // [Authorize]
    public IActionResult GetAllToppings()
    {
        return Ok(_dbContext.Toppings);
    }


}
