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
        VaccCentre GetVaccCentreByID(int id);
        List<VaccCentre> GetAllStates(string state);
        List<VaccCentre> GetAllStatesAndDistricts(string state, string district);   
        VaccCentre UpdateVaccCentre(VaccCentre vaccCentre);
        void DeleteVaccCentre(int id);
    }
}
