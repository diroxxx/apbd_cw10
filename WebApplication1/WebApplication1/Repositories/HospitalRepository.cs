using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HospitalRepository: IHospitalRepository
{
    private readonly ApplicationContext _context;

    public HospitalRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(int idPatient)
    {
        var isIdPatient = await _context.Patients.AnyAsync(i => i.IdPatient == idPatient);
        return isIdPatient;
    }

    public async Task<bool> DoesMedicamentExist(int idMedicament)
    {
        var isIdMed = await _context.Medicaments.AnyAsync(i => i.IdMedicament == idMedicament);
        return isIdMed;
    }

    public async Task addPatient(Patient patient)
    {
        _context.Patients.Add(new Patient()
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate
        });
       await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesDueDataGratherOrEqualData(DateTime DueData, DateTime Data)
    {
        if (DueData >= Data)
        {
            return true;
        }

        return false;
    }
}