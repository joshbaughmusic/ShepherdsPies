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

    // [HttpPost("create")]
    // // [Authorize]
    // public IActionResult PostOrder(Order newOrder)
    // {
    //     Order orderToSubmit = new Order
    //     {
    //         EmployeeId = newOrder.EmployeeId,
    //         CustomerId = newOrder.CustomerId,
    //         Date = DateTime.Now,
    //         Delivery = newOrder.Delivery,
    //         Tip = newOrder.Tip,
    //     };

    //     List<Pizza> newPizzas = new List<Pizza>();

    //     foreach (Pizza p in newOrder.Pizzas)
    //     {
    //         Pizza pizza = new Pizza
    //         {
    //             SizeId = p.SizeId,
    //             CheeseId = p.CheeseId,
    //             SauceId = p.SauceId
    //         };

    //         List<Topping> newToppings = new List<Topping>();

    //         foreach (Topping t in p.Toppings)
    //         {
    //             Topping foundTopping = _dbContext.Toppings.Single(t2 => t.Id == t2.Id);
    //             newToppings.Add(foundTopping);
    //         }
    //         pizza.Toppings = newToppings;
    //         newPizzas.Add(pizza);
    //     }
    //     orderToSubmit.Pizzas = newPizzas;

    //     _dbContext.Orders.Add(orderToSubmit);

    //     _dbContext.SaveChanges();

    //     return Created($"/api/order/{orderToSubmit.Id}", orderToSubmit);
    // }
}
