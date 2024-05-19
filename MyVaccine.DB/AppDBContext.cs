using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVaccine.DB
{
    public class AppDBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-ACI1598;Initial Catalog=MyVaccine;Integrated Security=True;Trust Server Certificate=True");
        }

        public DbSet<Applicants> applicants { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<VaccCentre> vaccCentres { get; set; }
        public DbSet<Admin> admins { get; set; }

    }
}
