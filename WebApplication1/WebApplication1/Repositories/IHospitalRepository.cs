using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public interface IHospitalRepository
{
    Task<bool> DoesPatientExist(int idPatient);
    Task<bool> DoesMedicamentExist(int idMedicament);
    Task addPatient(AddPatientDTO patient);
    Task<bool> DoesDueDataGratherOrEqualData(DateTime DueData, DateTime Data);
    Task<bool> DoesDoctorExist(int idDoctor);
    Task<int> AddPrescription(AddPrescription addPrescription);
    Task AddPrescriptionAndMedicament(int idPrescription, AddMeddDTO addMeddDto);
    Task<IEnumerable<GetPrescription>> GetPrescription(int idPatient);
    Task<PatientDTO> GetPatient(int idPatient);

    // Task<GetPrescription>






}