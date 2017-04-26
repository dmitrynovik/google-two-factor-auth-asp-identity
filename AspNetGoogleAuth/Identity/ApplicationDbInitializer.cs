using System.Data.Entity;
using AspNetGoogleAuth.Migrations;

namespace AspNetGoogleAuth.Identity
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration> 
    {
        
    }
}