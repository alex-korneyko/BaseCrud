using System;
using BaseCrud.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaseCrud.Context
{
    public class BaseCrudDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasData(new AppUser
                {
                    Id = 1,
                    Created = DateTime.Now,
                    Login = "admin",
                    Name = "admin",
                    Password = "111",
                    IsActive = true,
                    IsEnabled = true,
                    IsAdUser = false
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}