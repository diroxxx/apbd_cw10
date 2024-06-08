using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
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

    public async Task addPatient(AddPatientDTO patient)
    {
        _context.Patients.Add(new Patient()
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate
        });
       await _context.SaveChangesAsync();
    }

    public async  Task<bool> DoesDueDataGratherOrEqualData(DateTime DueData, DateTime Data)
    {
        if (DueData >= Data)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> DoesDoctorExist(int idDoctor)
    {
        var isDoctor = await _context.Doctors.AnyAsync(i => i.IdDoctor == idDoctor);
        return isDoctor;
    }

    public async Task<int> AddPrescription(AddPrescription addPrescription)
    {
        var addedPre = new Prescription()
        {
            Date = addPrescription.Date,
            DueDate = addPrescription.DueDate,
            IdPatient = addPrescription.patient.IdPatient,
            IdDoctor = addPrescription.IdDoctor
        };
        
        _context.Prescriptions.Add(addedPre);
        await _context.SaveChangesAsync();
        return addedPre.IdPrescription;
    }

    public async Task AddPrescriptionAndMedicament(int idPrescription, AddMeddDTO addMeddDto)
    {
        var pre_med = new PrescriptionMedicament()
        {
            IdMedicament = addMeddDto.idMedicament,
            IdPrescription = idPrescription,
            Dose = addMeddDto.Dose,
            Details = addMeddDto.Details
        };

        _context.PrescriptionMedicaments.Add(pre_med);
        await _context.SaveChangesAsync();
    }

    

    public async Task<IEnumerable<GetPrescription>> GetPrescription(int idPatient)
    {
        var result = await _context.Prescriptions
            .Where(p => p.IdPatient == idPatient)
            .Select(p => new GetPrescription
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Medicaments = p.PrescriptionMedicaments
                    .Join(_context.Medicaments,
                        pm => pm.IdMedicament,
                        m => m.IdMedicament,
                        (pm, m) => new GetMedicament
                        {
                            IdMedicaments = m.IdMedicament,
                            Name = m.Name,
                            Description = m.Description,
                            Dose = pm.Dose,
                        })
                    .ToList(),
                Doctor = new GetDoctor
                {
                    IdDoctor = p.Doctor.IdDoctor,
                    FirstName = p.Doctor.FirstName,
                }
            })
            .ToListAsync();

        return result;
    }


    public async Task<PatientDTO> GetPatient(int idPatient)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(i => i.IdPatient == idPatient);
        return new PatientDTO()
        {
            idPesel = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate
        };
    }
    
    
}