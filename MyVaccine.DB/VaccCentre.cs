using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.DB
{
    public class VaccCentre
    {
        [Key]
        public int centreId { get; set; }
        public string centreName { get; set; }
        public string state { get; set; }
        public string distrct {  get; set; }
        public string address { get; set; }


    }
}
