using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public CustomerController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllCustomers()
    {
        return Ok(_dbContext.Customers);
    }

    [HttpPost]
    //[Authorize]
    public IActionResult CreateCustomer(Customer newCustomer)
    {
        _dbContext.Customers.Add(newCustomer);
        _dbContext.SaveChanges();
        return Created($"api/customer/{newCustomer.Id}", newCustomer);
    }
}
