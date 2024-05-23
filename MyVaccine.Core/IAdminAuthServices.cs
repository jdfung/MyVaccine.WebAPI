using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.Core
{
    

    public interface IAdminAuthServices
    {

        Admin RegisterAdmin(string username, string password);
        string LoginAdmin(string username, string password);
    }
}
