using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/")]
public class HospitalController:ControllerBase
{
    private readonly IHospitalRepository _hospitalRepository;

    public HospitalController(IHospitalRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }

    [HttpPost]
    [Route("getPre")]
    public async Task<IActionResult> AddPrescription(AddPrescription addPrescription)
    {
        if (!await _hospitalRepository.DoesPatientExist(addPrescription.patient.IdPatient))
        {
          await _hospitalRepository.addPatient(addPrescription.patient);
        }

        if (addPrescription.medicaments.Count > 10)
        {
            return BadRequest("To much medicaments added(max 10)");
        }

        if (!await _hospitalRepository.DoesDueDataGratherOrEqualData(addPrescription.DueDate, addPrescription.Date))
        {
            return BadRequest("DueData is not grather or equal to Data");
        }
        
        

        List<PrescriptionMedicament> medicaments = new List<PrescriptionMedicament>();
        foreach (var medicament  in addPrescription.medicaments)
        {
            if (! await _hospitalRepository.DoesMedicamentExist(medicament.idMedicament))
            {
                return NotFound("Given Medicament doesn't exists");
            }

            if (!await _hospitalRepository.DoesDoctorExist(addPrescription.IdDoctor))
            {
                return NotFound("Given idDoctor doesn't exists");
            }
            
            // medicaments.Add();
           
        }
        
         using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    { 
                        var idPrescription = await _hospitalRepository.AddPrescription(addPrescription);
        
                        foreach (var medd in addPrescription.medicaments) 
                        {
                            await _hospitalRepository.AddPrescriptionAndMedicament(idPrescription, medd);
                        }
                        scope.Complete();
                    }
        
        
        
        return Ok();
    }


    [HttpGet]
    [Route("getInfo/{idPatient}")]
    public async Task<IActionResult> GetPatient(int idPatient)
    {
        if (!await _hospitalRepository.DoesPatientExist(idPatient))
        {
            return NotFound("Given idPatient doesn't exist");
        }
        var result = await _hospitalRepository.GetPrescription(idPatient);
        
        
        GetPatient infoAboutPatient = new GetPatient();
        infoAboutPatient.Patient = await _hospitalRepository.GetPatient(idPatient);
        infoAboutPatient.Prescriptions = result;
        
        
        
        
        return Ok(infoAboutPatient);
    }
    
}