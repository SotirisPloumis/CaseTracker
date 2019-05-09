namespace CaseTracker.Migrations
{
	using CaseTracker.Controllers;
	using CaseTracker.Models;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using System.Web;
	using Microsoft.Owin.Security;
	using System.Data.Entity.Validation;
	using System.Diagnostics;

	internal sealed class Configuration : DbMigrationsConfiguration<CaseTracker.Repository.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CaseTracker.Repository.ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			//admin, users and roles
			var AdminRole = new IdentityRole
			{
				Id = "1",
				Name = "Admin"
			};

			var UserRole = new IdentityRole
			{
				Id = "2",
				Name = "User"
			};

			context.Roles.AddOrUpdate(AdminRole);
			context.Roles.AddOrUpdate(UserRole);

			var Hasher = new PasswordHasher();
			string HashedPassword = Hasher.HashPassword("Qwerty1!");

			ApplicationUser Admin = new ApplicationUser()
			{
				UserName = "admin@admin.com",
				PasswordHash = HashedPassword,
				Email = "admin@admin.com",
				SecurityStamp = Guid.NewGuid().ToString(),
				IsPro = true
			};

			context.Users.AddOrUpdate(Admin);

			var AdminIsAdmin = new IdentityUserRole
			{
				RoleId = AdminRole.Id,
				UserId = Admin.Id
			};

			Admin.Roles.Add(AdminIsAdmin);

			//case roles
			context.CaseRoles.AddOrUpdate(new CaseRole() { Title = "Prosecution", Type = RoleType.Accuse});
			context.CaseRoles.AddOrUpdate(new CaseRole() { Title = "Defense", Type = RoleType.Defend});
			context.CaseRoles.AddOrUpdate(new CaseRole() { Title = "Recipient", Type = RoleType.Receive});

			//deed results	
			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Anepidoto_Anamoni_Neas_Address", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Anepidoto_Apeviose", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Anepidoto_Katoikos_Eksoterikou", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Anepidoto_Lathos_Address", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Apli_Thirokolisi", IsPayable = true});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Epidosi", IsPayable = true});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Mataiosi_AM_Apli_Thirokolisi", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Mataiosi_AM_Epidosi", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Mataiosi_AM_Pliris_Thirokolisi", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Pausi_Ergasion", IsPayable = false});

			context.DeedResults.AddOrUpdate(new DeedResult() {
				Result = "dr_Pliris_Thirokolisi", IsPayable = true});

			//document types		
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Agogi" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Aitisi" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Aitisi_Anastolis" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Anakopi" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Apofasi_Pros_Epitagi" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Apofasi_Pros_Gnosi" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Diafora" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Diatagi_Apodosis_Xrisis_Misthiou" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Diatagi_Pliromis" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Efesi" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Eggrafo_Timologiou" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Eksodiko" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Gnostopoiisi_Martyron" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Klisi" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Perilipsi_Epimeliti_Eparxeias" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Praktiko_Anavolis" });
			context.DocumentTypes.AddOrUpdate(new DocumentType() { Description = "dt_Prosfygi" });

			//zones
			context.Zones.AddOrUpdate(new Zone() { Name = "ZoneA", CostFull = 35, CostClean = 28});
			context.Zones.AddOrUpdate(new Zone() { Name = "ZoneB", CostFull = 55, CostClean = 44});
			context.Zones.AddOrUpdate(new Zone() { Name = "ZoneC", CostFull = 73, CostClean = 58.40M});
			context.Zones.AddOrUpdate(new Zone() { Name = "ZoneD", CostFull = 95, CostClean = 76});

			try
			{
				context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach(var msg in e.EntityValidationErrors)
				{
					Debug.Print(msg.ToString());
				}
				
				//throw;
			}
        }
    }
}
