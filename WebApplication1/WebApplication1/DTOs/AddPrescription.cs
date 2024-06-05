using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class AddPrescription
{
    public Patient patient { get; set; }
    public List<Medicament> medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
}