using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Models;

public class Employee
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [NotMapped]
    public string UserName { get; set; }
    [NotMapped]
    public List<string> Roles { get; set; }

    [Required]
    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
}