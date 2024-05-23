using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.DB
{
    public class Admin
    {
        [Key]
        public int adminId {  get; set; }
        public string adminUserName { get; set; } = string.Empty;
        public string adminPasswordHash { get; set; } = string.Empty;
    }
}
