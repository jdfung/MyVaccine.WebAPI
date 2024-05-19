using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.Core
{
    public class VaccCentreServices : IVaccCentreServices
    {
        private readonly AppDBContext _context;

        public VaccCentreServices(AppDBContext context)
        {
            _context = context;
        }
       
        public List<VaccCentre> GetAllRecords()
        {
            return _context.vaccCentres.ToList();
        }

        public VaccCentre AddNewCentreEntry(VaccCentre vaccCentre)
        {
            _context.Add(vaccCentre);
            _context.SaveChanges();

            return vaccCentre;
        }

        public List<VaccCentre> GetAllStates(string state)
        {
            var response = _context.vaccCentres.ToList().FindAll(x => x.state == state);
            return response;
        }

        public List<VaccCentre> GetAllStatesAndDistricts(string state, string district)
        {
            var response = _context.vaccCentres.ToList().FindAll(x => x.state.Equals(state) && x.distrct.Equals(district));
            return response;
        }
    }
}
