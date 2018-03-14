using AutoDem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    class AutoDemDatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var RoleUser = new ApplicationRole()
            {
                Name = "Admin",
                Description = "Administrator"
            };

            context.SaveChanges();
        }
    }
}
