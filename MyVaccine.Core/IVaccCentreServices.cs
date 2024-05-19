using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.Core
{
    public interface IVaccCentreServices
    {
        List<VaccCentre> GetAllRecords();
        VaccCentre AddNewCentreEntry(VaccCentre vaccCentre);
        List<VaccCentre> GetAllStates(string state);
        List<VaccCentre> GetAllStatesAndDistricts(string state, string district);   
    }
}
