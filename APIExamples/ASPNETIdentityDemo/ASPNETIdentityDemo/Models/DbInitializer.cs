using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNETIdentityDemo.Models
{
    public class DbInitializer:DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "MonUtilisateurQuiExisteraToujours@henallux.be",
                EmailConfirmed = true,
            };

            manager.Create(user, "MySuperP@ssword!");
        }
    }
}