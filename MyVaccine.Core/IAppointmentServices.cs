using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.Core
{
    public interface IAppointmentServices
    {
        List<Appointment> GetAppointments();
        Appointment GetAppointmentByICName(string ic, string name);
        Appointment GetAppointmentbyID(int id);
        Appointment AddAppointment(Appointment appointment);
        Appointment UpdateAppointmentNameIC(int appointment_id, string name);
        Appointment AssignAppointmentDate(int appointment_id, DateTime date);
        Appointment removeAppointmentDate(int appointment_id, int appointmentDose);
    }
}
