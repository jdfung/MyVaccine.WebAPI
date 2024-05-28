using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.Core;
using MyVaccine.DB;

namespace MyVaccine.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VaccCentreController : ControllerBase
    {
        private readonly IVaccCentreServices _services;

        public VaccCentreController(IVaccCentreServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult getAllRecords()
        {
            var response = _services.GetAllRecords();
            return Ok(response);
        }

        [HttpGet("GetByID/")]
        public IActionResult getRecordsByID(int id) {
        
            var response = _services.GetVaccCentreByID(id);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("state")]
        public IActionResult getAllStates(string state)
        {
            var response = _services.GetAllStates(state);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("district")]
        public IActionResult getAllStatesAndDistricts(string state, string district) {

            var response = _services.GetAllStatesAndDistricts(state, district);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut, Authorize]
        public IActionResult updateVaccCentre(VaccCentre vaccCentre)
        {
            var response = _services.UpdateVaccCentre(vaccCentre);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost, Authorize]
        public IActionResult addNewCentreEntry(VaccCentre vaccCentre) {

            var response = _services.AddNewCentreEntry(vaccCentre);
            return Ok(response);
        }

        [HttpDelete, Authorize]
        public IActionResult deleteCentreEntry(int id)
        {
            _services.DeleteVaccCentre(id);
            return Ok(_services.GetAllRecords());
        }
    }
}
