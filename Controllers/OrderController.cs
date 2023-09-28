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

    [HttpPost]
    // [Authorize]
    public IActionResult PostOrder(Order newOrder)
    {
        Order orderToSubmit = new Order
        {
            EmployeeId = newOrder.EmployeeId,
            Employee = _dbContext.Employees.SingleOrDefault(e => e.Id == newOrder.EmployeeId),
            CustomerId = newOrder.CustomerId,
            Customer = _dbContext.Customers.SingleOrDefault(e => e.Id == newOrder.CustomerId),
            Date = DateTime.Now,
            Delivery = newOrder.Delivery,
            Tip = newOrder.Tip,
        };

        List<Pizza> newPizzas = new List<Pizza>();

        foreach (Pizza p in newOrder.Pizzas)
        {
            Pizza pizza = new Pizza
            {
                SizeId = p.Size.Id,
                Size = _dbContext.Sizes.SingleOrDefault(s => s.Id == p.Size.Id),
                CheeseId = p.Cheese.Id,
                SauceId = p.Sauce.Id,
                PizzaToppings = new List<PizzaTopping>()
            };

            foreach (PizzaTopping pt in p.PizzaToppings)
            {
                pt.Topping = _dbContext.Toppings.SingleOrDefault(t => t.Id == pt.ToppingId);

                pizza.PizzaToppings.Add(pt);
            }

            newPizzas.Add(pizza);
        }
        orderToSubmit.Pizzas = newPizzas;

        _dbContext.Orders.Add(orderToSubmit);

        _dbContext.SaveChanges();

        return Created($"/api/order/{orderToSubmit.Id}", orderToSubmit);
    }

    [HttpDelete("{id}")]
    // [Authorize]
    public IActionResult CancelOrder(int id)
    {
        Order orderToRemove = _dbContext.Orders.SingleOrDefault(p => p.Id == id);

        if (orderToRemove == null)
        {
            return NotFound();
        }
        _dbContext.Orders.Remove(orderToRemove);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("{orderId}/assign/{employeeId}")]
    // [Authorize]
    public IActionResult AssignDriver(int orderId, int employeeId)
    {
        Order orderToUpdate = _dbContext.Orders.SingleOrDefault(o => o.Id == orderId);
        Employee employeeToAssign = _dbContext.Employees.SingleOrDefault(e => e.Id == employeeId);
        if (orderToUpdate == null || employeeToAssign == null)
        {
            return NotFound();
        }
        orderToUpdate.DriverId = employeeId;
        orderToUpdate.Driver = employeeToAssign;

        _dbContext.SaveChanges();

        return NoContent();
    }

}

