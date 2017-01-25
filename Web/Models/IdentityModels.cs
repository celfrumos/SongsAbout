using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SongsAbout.Web;

namespace SongsAbout.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, 
    // please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        public override string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }

        public override string PasswordHash
        {
            get { return base.PasswordHash; }
            set { base.PasswordHash = value; }
        }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(Properties.Settings.Default.DbConnectionString, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}