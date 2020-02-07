using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OnionArch.Infrastructure.Data
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext([NotNull] DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>(r => r.HasData(new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "Admin"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "DEV",
                    NormalizedName = "Developer"

                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "BA",
                    NormalizedName = "Business Analyst"

                },
                new IdentityRole
                {
                    Id = "4",
                    Name = "QA",
                    NormalizedName = "Quality Assurance"
                },
                new IdentityRole
                {
                    Id = "5",
                    Name = "BU",
                    NormalizedName = "Business User"
                }
            ));

            base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> User { get; set; }



    }
}
