using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models;

public class Pizza
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    public decimal TotalCost { get; }
    public int SizeId { get; set; }
    public int CheeseId { get; set; }
    public int SauceId { get; set; }
    public Size Size { get; set; }
    public Cheese Cheese { get; set; }
    public Sauce Sauce { get; set; }
    public List<PizzaTopping> PizzaToppings { get; set; }
}