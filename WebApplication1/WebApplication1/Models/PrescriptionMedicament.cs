using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdPrescription), nameof(IdMedicament))]
public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdMedicament))]
    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdPrescription))]
    
    public int? Dose { get; set; }
    public String Details { get; set; } = String.Empty;

    public Medicament Medicament { get; set; } = null!;
    public Prescription Prescription { get; set; } = null!;

}