using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public EmployeeController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Employees.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.Employees
        .Include(up => up.IdentityUser)
        .Select(up => new Employee
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetWithAssignedAndCompletedChores(int id)
    {

        Employee up = _dbContext.Employees
        .SingleOrDefault(up => up.Id == id);

        if (up == null)
        {
            return NotFound();
        }

        return Ok(up);
    }

    // [HttpPost("promote/{id}")]
    // [Authorize(Roles = "Admin")]
    // public IActionResult Promote(string id)
    // {
    //     IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");

    //     _dbContext.UserRoles.Add(new IdentityUserRole<string>
    //     {
    //         RoleId = role.Id,
    //         UserId = id
    //     });
    //     _dbContext.SaveChanges();
    //     return NoContent();
    // }

    // [HttpPost("demote/{id}")]
    // [Authorize(Roles = "Admin")]
    // public IActionResult Demote(string id)
    // {
    //     IdentityRole role = _dbContext.Roles
    //         .SingleOrDefault(r => r.Name == "Admin"); 
    //     IdentityUserRole<string> userRole = _dbContext
    //         .UserRoles
    //         .SingleOrDefault(ur =>
    //             ur.RoleId == role.Id &&
    //             ur.UserId == id);

    //     _dbContext.UserRoles.Remove(userRole);
    //     _dbContext.SaveChanges();
    //     return NoContent();
    // }

}