using System.Runtime.InteropServices.JavaScript;
using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class GetPatient
{
    public Patient Patient { get; set; }
    public List<GetPrescription> Type { get; set; }
}

public class GetPrescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<GetMedicament> Medicaments { get; set; }
    public GetDoctor Doctor { get; set; }
}

public class GetMedicament
{
    public  int IdMedicaments { get; set; }
    public  String Name { get; set; }
    public  int Dose { get; set; }
    public  String Description { get; set; }
}

public class GetDoctor
{
    public int IdDoctor { get; set; }
    public String FirstName { get; set; }
}
