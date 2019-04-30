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
		public DbSet<DocumentType> DocumentTypes { get; set; }
		public DbSet<DeedResult> DeedResults { get; set; }
		public DbSet<Zone> Zones { get; set; }

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