using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShepherdsPies.Models;

public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int? DriverId { get; set; }
    public int CustomerId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public bool Delivery { get; set; }
    public decimal? Tip { get; set; }
    private decimal DeliverySurcharge { get; } = 5.00M;
    public decimal? TotalCost { 
        get
        {
            decimal? total = 0.00m;
            foreach (Pizza p in Pizzas)
            {
                total += p.TotalCost;
            }
            if (Delivery)
            {
                total += DeliverySurcharge;
            }
                total += Tip;
            return total;
        }
    }   
    public List<Pizza> Pizzas { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
    [ForeignKey("DriverId")]
    public Employee? Driver { get; set; }
    public Customer Customer { get; set; }
}