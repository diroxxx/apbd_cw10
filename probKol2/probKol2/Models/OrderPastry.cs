using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace probKol2.Models;
[Table("Order_Pastry")]
[PrimaryKey(nameof(OrderID), nameof(PastryID))]
public class OrderPastry
{
    public int OrderID{ get; set; }
     [ForeignKey(nameof(OrderID))]
    public int PastryID{ get; set; }
   [ForeignKey(nameof(PastryID))]
   
    public int Amount{ get; set; }
    
    [MaxLength(300)]
    public String? Comme { get; set; }

    public Pastry Pastry { get; set; } = null!;
    public Order Order { get; set; } = null!;
}