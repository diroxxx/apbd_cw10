using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class AddPrescription
{
    public int IdDoctor { get; set; }
    public AddPatientDTO patient { get; set; }
    public List<AddMeddDTO> medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
}

public class AddMeddDTO
{
    public int idMedicament { get; set; }
    public int Dose { get; set; }
    public String Details { get; set; }
}

public class AddPatientDTO
{
    public int IdPatient { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateTime Birthdate { get; set; }
}