using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAccess.Entities;

namespace NajotTalim.HR.DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextoptions) : base(dbContextoptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
             .Property(e => e.Email)
             .HasDefaultValueSql("'savobmedia@gmail.com'");


            modelBuilder.Entity<Address>()
                .HasData(
                new Address
                {
                    Id = 1995,
                    AddressLine1 = "Imom Buuxriy 11",
                    AddressLine2 = "To'ytepa 1",
                    PostalCode = "4700",
                    Country = " O'zbekiston",
                    City = "Tshkent"
                }
                );
        }
    }
}