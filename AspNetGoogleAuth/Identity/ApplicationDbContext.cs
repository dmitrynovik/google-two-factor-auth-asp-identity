using System.Data.Entity;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetGoogleAuth.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.Log = msg => Debug.WriteLine(msg);
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer(new ApplicationDbInitializer());            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}