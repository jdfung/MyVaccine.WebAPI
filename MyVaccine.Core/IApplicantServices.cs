using MyVaccine.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.Core
{
    public interface IApplicantServices
    {
        List<Applicants> GetApplicants();
        Applicants GetApplicantByICName(string ic, string name);
        Applicants GetApplicantById(int id);
        Applicants GetApplicantByIc(string ic);
        Applicants AddApplicants(Applicants applicants);
        Applicants UpdateApplicants(Applicants applicants);
    }
}
