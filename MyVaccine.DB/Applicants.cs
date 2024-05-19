using System.ComponentModel.DataAnnotations;

namespace MyVaccine.DB
{
    public class Applicants
    {
        [Key]
        public int applicant_id { get; set; }
        public string name { get; set; }
        public string ic {  get; set; }
        public string gender { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public bool firstDose { get; set; }
        public bool secondDose { get; set; }

    }
}
