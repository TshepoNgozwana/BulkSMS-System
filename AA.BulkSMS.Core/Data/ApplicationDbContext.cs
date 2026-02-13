using AA.BulkSMS.Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AA.BulkSMS.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<SystemUser>
    {
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ensure Organisation.Code is unique and acts as the principal key
            builder.Entity<Organisation>()
                .HasIndex(o => o.Code)
                .IsUnique();

            builder.Entity<Organisation>()
                .HasMany(o => o.Users)
                .WithOne(u => u.Organisation)
                .HasForeignKey(u => u.OrganisationId)
                .HasPrincipalKey(o => o.Code) // Map OrganisationId to Code
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Super User", NormalizedName = "SUPER USER" },
                new IdentityRole { Id = "2", Name = "Company Administrator", NormalizedName = "COMPANY ADMINISTRATOR" },
                new IdentityRole { Id = "3", Name = "Company Manager", NormalizedName = "COMPANY MANAGER" },
                new IdentityRole { Id = "4", Name = "Company Supervisor", NormalizedName = "COMPANY SUPERVISOR" },
                new IdentityRole { Id = "5", Name = "Company General User", NormalizedName = "COMPANY GENERAL USER" }
            );
        }

        public async Task<string> SeedOrganisationAsync(string name, string description, string addedBy)
        {
            var sql = "EXEC cfg_Organisation_Save @p0, @p1, @p2";

            var organisation = await Task.Run(() => Organisations
                .FromSqlRaw(sql, name, description, addedBy)
                .AsNoTracking()
                .AsEnumerable() // Forces client-side execution
                .FirstOrDefault());

            return organisation?.Code;
        }
    }
}
