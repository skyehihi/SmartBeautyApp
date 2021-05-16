using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBeauty.Models;

namespace SmartBeauty.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<SmartBeauty.Models.Appointment> Appointment { get; set; }
        public DbSet<SmartBeauty.Models.Client> Client { get; set; }
        public DbSet<SmartBeauty.Models.TimeSpot> TimeSpot { get; set; }
        public DbSet<SmartBeauty.Models.LastAppointment> LastAppointment { get; set; }
        public DbSet<SmartBeauty.Models.Service> Service { get; set; }
        public DbSet<SmartBeauty.Models.Staff> Staff { get; set; }
        public DbSet<SmartBeauty.Models.Salon> Salon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Salon>().ToTable("Salon");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<LastAppointment>().ToTable("LastAppointment");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<TimeSpot>().ToTable("TimeSpot");

        }

    }
}
