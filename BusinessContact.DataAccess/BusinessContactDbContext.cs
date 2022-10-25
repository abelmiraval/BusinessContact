using System;
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

        public DbSet<District> Districts { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
