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

            var typeAuto1 = new TypeAuto()
            {
                Name = "Седан"
            };

            var typeAuto2 = new TypeAuto()
            {
                Name = "Універсал"
            };

            var typeAuto3 = new TypeAuto()
            {
                Name = "Хетчбек"
            };


            context.TypesAuto.AddRange(new TypeAuto[] { typeAuto1, typeAuto2, typeAuto3 });
            context.Roles.Add(RoleUser);
            context.SaveChanges();
        }
    }
}
