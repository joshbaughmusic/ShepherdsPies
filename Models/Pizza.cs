using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models;

public class Pizza
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    public decimal? TotalCost { get
        {
            decimal? total = 0.00m;
            
                total += Size.Price;
                if (PizzaToppings.Count > 0)
                {
                    total += PizzaToppings.Count * 0.50m;
                }
           
            return total;
        } }
    public int SizeId { get; set; }
    public int CheeseId { get; set; }
    public int SauceId { get; set; }
    public Size Size { get; set; }
    public Cheese Cheese { get; set; }
    public Sauce Sauce { get; set; }
    public List<PizzaTopping> PizzaToppings { get; set; }
}