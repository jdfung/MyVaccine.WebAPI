using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.Core;
using MyVaccine.DB;

namespace MyVaccine.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentServices _services;

        public AppointmentsController(IAppointmentServices appointmentServices)
        {
            _services = appointmentServices;
        }

        [HttpGet, Authorize]
        public IActionResult GetAppointments()
        {
            return Ok(_services.GetAppointments());
        }

        [HttpGet("{IcName}", Name = "GetSpeciAppointment")]
        public IActionResult GetSpeciAppointment(string ic, string name)
        {
            var response = _services.GetAppointmentByICName(ic, name);
            if(response == null)
            {
                var errorResponse = NotFound();
                return Ok(errorResponse);
            }
            else
            {
                return Ok(response);
            }
            
        }

        [HttpGet("GetByID/"), Authorize]
        public IActionResult GetAppointmentByID(int id)
        {
            var response = _services.GetAppointmentbyID(id);
            if(response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult addAppointment(Appointment appointment)
        {
            var newAppointment = _services.AddAppointment(appointment);
            return Ok(_services.GetAppointments());
        }

        [HttpPut("UpdateNameIC/")]
        public IActionResult updateAppointmentNameIC(int id, string name)
        {
            _services.UpdateAppointmentNameIC(id, name);
            return Ok(_services.GetAppointments());
        }

        [HttpPut("AssignDate/"), Authorize]
        public IActionResult assignAppointmentDate(int id, DateTime date)
        {
            _services.AssignAppointmentDate(id, date);
            return Ok(_services.GetAppointments());
        }

        [HttpPut("DeleteDate/")]
        public IActionResult deleteAppointmentDate(int id, int dose) {

            _services.removeAppointmentDate(id, dose);
            return Ok(_services.GetAppointments());
        }
    }
}
