using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models;

public class Customer
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }
    public long Phone { get; set; }
    public List<Order> Orders { get; set; }
}