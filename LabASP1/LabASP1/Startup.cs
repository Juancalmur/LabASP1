using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LabASP1.Models;

[assembly: OwinStartupAttribute(typeof(LabASP1.Startup))]
namespace LabASP1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)   
        {   
            ConfigureAuth(app);   
            createRolesandUsers();   
        }   
   
   
        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()   
        {   
            ApplicationDbContext context = new ApplicationDbContext();   
   
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));   
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))   
            {   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
                role.Name = "Manager";   
                roleManager.Create(role);   
   
            }   
   
            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))   
            {   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
                role.Name = "Employee";   
                roleManager.Create(role);   
   
            }   
        } 
    }
}
