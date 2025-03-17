using Microsoft.EntityFrameworkCore;
using Rapha_LIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<AnalyticsPatientModel> AnalyticsPatients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set default value for 'Result' column in UserModel
            modelBuilder.Entity<PatientModel>()
                .Property(p => p.Result)
                .HasDefaultValue("Pending");

            modelBuilder.Entity<AnalyticsPatientModel>()
        .Property(p => p.Id)
        .ValueGeneratedNever(); // 🔹 This disables auto-increment
        }
    }
}
