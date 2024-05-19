using MyVaccine.DB;

namespace MyVaccine.Core
{
    public class ApplicantServices : IApplicantServices
    {
        private readonly AppDBContext _context;

        public ApplicantServices(AppDBContext context)
        {
            _context = context;
        }

        public List<Applicants> GetApplicants()
        {
            return _context.applicants.ToList();
        }

        public Applicants GetApplicantByICName(string ic, string name)
        {
            return _context.applicants.First(x => x.ic == ic && x.name == name);
        }

        public Applicants GetApplicantById(int id)
        {
            return _context.applicants.First(x => x.applicant_id == id);
        }

        public Applicants GetApplicantByIc(string ic)
        {
            return _context.applicants.First(x => x.ic.Equals(ic));
        }

        public Applicants AddApplicants(Applicants applicants)
        {
            _context.Add(applicants);
            _context.SaveChanges();

            return applicants;
        }

        public Applicants UpdateApplicants(Applicants applicants)
        {
            var dbApplicants = _context.applicants.First(x => x.applicant_id == applicants.applicant_id);
            dbApplicants.name = applicants.name;
            dbApplicants.ic = applicants.ic;
            dbApplicants.phoneNo = applicants.phoneNo;
            dbApplicants.email = applicants.email;
            dbApplicants.address = applicants.address;

            _context.SaveChanges();
            return dbApplicants;
        }

        
    }
}
