using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OrderController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public OrderController(ShepherdsPiesDbContext context)
    {
       _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllOrders()
    {
        return Ok(_dbContext.Orders.Include(o => o.Customer).Include(o => o.Pizzas).ThenInclude(p => p.Size).Include(o => o.Pizzas).ThenInclude(p => p.PizzaToppings));
    }
    
    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetSingleOrder(int id)
    {
        Order order = _dbContext.Orders
        .Include(o => o.Customer)
        .Include(o => o.Employee)
        .Include(o => o.Driver)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.Size)
        .Include(o => o.Pizzas)
        .ThenInclude(p => p.PizzaToppings)
        .ThenInclude(pt => pt.Topping)
        .SingleOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
}
