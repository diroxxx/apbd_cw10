using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [MaxLength(100)] public String FirstName { get; set; } = String.Empty;
    [MaxLength(100)]
    public String LastName { get; set; } = String.Empty;
    [EmailAddress]

    public String Email { get; set; } = String.Empty;

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();

}