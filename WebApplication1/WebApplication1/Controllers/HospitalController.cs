using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;

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

        if (!await _hospitalRepository.DoesDueDataGratherOrEqualData(addPrescription.DueDate, addPrescription.Date))
        {
            return BadRequest("DueData is not grather or equal to Data");
        }
    }
    
}