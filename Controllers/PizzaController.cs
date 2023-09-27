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

    [HttpGet("{id}/")]
    // [Authorize]
    public IActionResult GetSinglePizza(int id)
    {
        return Ok(_dbContext.Pizzas.Include(p => p.Size).Include(p => p.Cheese).Include(p => p.Sauce).Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).SingleOrDefault(p => p.Id == id));
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

    [HttpPut("{orderId}/{pizzaId}/update")]
    // [Authorize]
    public IActionResult UpdatePizza(int pizzaId, Pizza updatedPizza)
    {
        Pizza pizzaToUpdate = _dbContext.Pizzas.SingleOrDefault(p => p.Id == pizzaId);

        if (pizzaToUpdate == null)
        {
            return NotFound();
        }

        pizzaToUpdate.SizeId = updatedPizza.SizeId;
        pizzaToUpdate.Size = _dbContext.Sizes.SingleOrDefault(x => x.Id == updatedPizza.SizeId);
        pizzaToUpdate.CheeseId = updatedPizza.CheeseId;
        pizzaToUpdate.Cheese = _dbContext.Cheeses.SingleOrDefault(x => x.Id == updatedPizza.CheeseId);
        pizzaToUpdate.SauceId = updatedPizza.SauceId;
        pizzaToUpdate.Sauce = _dbContext.Sauces.SingleOrDefault(x => x.Id == updatedPizza.SauceId);
        foreach (PizzaTopping pt in updatedPizza.PizzaToppings)
        {
            pt.Topping = _dbContext.Toppings.SingleOrDefault(t => t.Id == pt.ToppingId);
        }

        List<PizzaTopping> pizzaToppingsToRemove = _dbContext.PizzaToppings.Where(pt => pt.PizzaId == pizzaId).ToList();

        _dbContext.PizzaToppings.RemoveRange(pizzaToppingsToRemove);

        pizzaToUpdate.PizzaToppings = updatedPizza.PizzaToppings;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("{orderId}/add")]
    // [Authorize]
    public IActionResult AddPizza(int orderId, Pizza newPizza)
    {
        Pizza newPizzaToSubmit = new Pizza()
        {
            OrderId = orderId,
            SizeId = newPizza.SizeId,
            Size = _dbContext.Sizes.SingleOrDefault(x => x.Id == newPizza.SizeId),
            CheeseId = newPizza.CheeseId,
            Cheese = _dbContext.Cheeses.SingleOrDefault(x => x.Id == newPizza.CheeseId),
            SauceId = newPizza.SauceId,
            Sauce = _dbContext.Sauces.SingleOrDefault(x => x.Id == newPizza.SauceId)
        };
        foreach (PizzaTopping pt in newPizza.PizzaToppings)
        {
            pt.Topping = _dbContext.Toppings.SingleOrDefault(t => t.Id == pt.ToppingId);
        }

        newPizzaToSubmit.PizzaToppings = newPizza.PizzaToppings;

        _dbContext.Pizzas.Add(newPizzaToSubmit);

        _dbContext.SaveChanges();

        return Created($"api/pizza/{orderId}/{newPizzaToSubmit.Id}", newPizzaToSubmit);
    }

}
