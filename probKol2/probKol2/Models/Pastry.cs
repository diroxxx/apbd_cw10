using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace probKol2.Models;

[Table("Pastry")]
public class Pastry
{
   [Key] public int ID { get; set; }
   [MaxLength(150)]
    public String Name { get; set; }
    
    public Double Price { get; set; }
    [MaxLength(40)]
    public String Type { get; set; }

    public ICollection<OrderPastry> OrderPastries { get; set; } = new HashSet<OrderPastry>();
}