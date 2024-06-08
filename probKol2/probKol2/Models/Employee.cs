using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace probKol2.Models;
[Table("Employee")]
public class Employee
{
    public int ID { get; set; }
    [MaxLength(100)]
    public String FirstName  { get; set; }
    [MaxLength(100)]
    public String LastName  { get; set; }

    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}