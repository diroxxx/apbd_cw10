using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public interface IHospitalRepository
{
    Task<bool> DoesPatientExist(int idPatient);
    Task<bool> DoesMedicamentExist(int idMedicament);
    Task addPatient(Patient patient);
    Task<bool> DoesDueDataGratherOrEqualData(DateTime DueData, DateTime Data);
}