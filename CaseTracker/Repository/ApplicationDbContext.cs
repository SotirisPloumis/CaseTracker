using CaseTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CaseTracker.Repository
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Case> Cases { get; set; }
		public DbSet<Attorney> Attorneys { get; set; }
		public DbSet<Court> Courts { get; set; }
		public DbSet<CaseRole> CaseRoles { get; set; }
		public DbSet<Party> Parties { get; set; }
		public DbSet<CaseParties> CaseParties { get; set; }

		public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		public System.Data.Entity.DbSet<CaseTracker.Models.DocumentType> DocumentTypes { get; set; }
	}
}