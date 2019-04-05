using CaseTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CaseTracker.Repository
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Case> Cases { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}