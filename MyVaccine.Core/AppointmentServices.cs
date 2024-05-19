using Microsoft.EntityFrameworkCore;
using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.Core
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly AppDBContext _context;

        public AppointmentServices(AppDBContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAppointments()
        {
            return _context.appointments.ToList();
        }

        public Appointment GetAppointmentByICName(string ic, string name)
        {
            return _context.appointments.First(x => x.ic == ic && x.name == name);
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            _context.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment UpdateAppointmentNameIC(int appointment_id, string name)
        {
            var dbAppointment = _context.appointments.First(x => x.appointment_id == appointment_id);
            dbAppointment.name = name;
            //dbAppointment.ic = appointment.ic;
            _context.SaveChanges();
            return dbAppointment;
        }

        public Appointment removeAppointmentDate(int appointment_id, int appointmentDose)
        {
            var dbAppointment = _context.appointments.First(x => x.appointment_id == appointment_id);
            if(appointmentDose == 1)
            {
                dbAppointment.firstDoseDate = null;
            }
            else
            {
                dbAppointment.secondDoseDate = null;
            }

            _context.SaveChanges();
            return dbAppointment;
        }
    }
}
