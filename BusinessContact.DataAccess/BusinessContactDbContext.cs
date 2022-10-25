using System;
using System.Collections.Generic;
using BusinessContact.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessContact.DataAccess
{
    public class BusinessContactDbContext : DbContext
    {
        protected BusinessContactDbContext()
        {
        }

        public BusinessContactDbContext(DbContextOptions<BusinessContactDbContext> options) 
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<District>()
                .HasQueryFilter(p => p.Status)
                .Property(p => p.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Business>()
                .HasQueryFilter(p => p.Status)
                .Property(p => p.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Contact>()
                .HasQueryFilter(p => p.Status)
                .Property(p => p.Status)
                .HasDefaultValue(true);


            modelBuilder.Entity<District>()
                .HasData(new List<District>
                {
                    new District { Id = 1, Code = "LM", Name = "Lima"},
                    new District { Id = 2, Code = "CL", Name = "Callao"},
                    new District { Id = 3, Code = "LB", Name = "Libertad"},
                });

            modelBuilder.Entity<Business>()
                .HasData(new List<Business>
                {
                    new Business { Id = 1, Name = "In Learning", Number = "10702354769", Address = "Jr. Los pinos 567", DistrictId = 1},
                    new Business { Id = 2, Name = "IDAT", Number = "10702354754", Address = "Jr. Los Volcanes 667", DistrictId = 2},
                    new Business { Id = 3, Name = "Cibertec", Number = "20702354769" , Address = "Av. Los Angles 1029", DistrictId = 3},
                });

        }

        public DbSet<District> Districts { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
