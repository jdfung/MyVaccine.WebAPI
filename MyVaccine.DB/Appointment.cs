using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.DB
{
    public class Appointment
    {
        [Key]
        public int appointment_id { get; set; }
        public string ic {  get; set; }
        public string name { get; set; }
        public string vaccCenter { get; set; }
        public string vaccChoice { get; set; }
        public DateTime? firstDoseDate { get; set; }
        public DateTime? secondDoseDate { get;set; }

    }
}
