using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table("Patient")]
public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public String FirstName { get; set; } = String.Empty;
    [MaxLength(100)] 
    public String LastName { get; set; } = String.Empty;
    public DateTime Birthdate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}