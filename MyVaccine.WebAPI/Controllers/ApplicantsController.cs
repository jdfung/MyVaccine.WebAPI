using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVaccine.Core;
using MyVaccine.DB;

namespace MyVaccine.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantsController : ControllerBase
    {

        private readonly IApplicantServices _applicantServices;

        public ApplicantsController(IApplicantServices applicantServices)
        {
            _applicantServices = applicantServices;
        }

        [HttpGet]
        public IActionResult GetApplicants()
        {

            return Ok(_applicantServices.GetApplicants());
        }

        [HttpGet("{IcName}", Name = "GetSpeciApplicantByICName")]
        public IActionResult GetApplicantByICName(string ic, string name)
        {
            var response = _applicantServices.GetApplicantByICName(ic, name);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetByID/{id}", Name = "GetSpeciApplicantByID")]
        public IActionResult GetApplicantById(int id)
        {
            var response = _applicantServices.GetApplicantById(id);
            if(response == null )
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetByIc/{ic}")]
        public IActionResult GetApplicantByIc(string ic)
        {
            var response = _applicantServices.GetApplicantByIc(ic);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult addApplicant(Applicants applicants)
        {
            var newApplicant = _applicantServices.AddApplicants(applicants);
            //return CreatedAtRoute("GetExpense", new { newApplicant.applicant_id }, newApplicant);
            return Ok(_applicantServices.GetApplicants());
        }

        [HttpPut]
        public IActionResult updateApplicant(Applicants applicants)
        {
            _applicantServices.UpdateApplicants(applicants);
            return Ok(_applicantServices.GetApplicants());
        }

    }
}
