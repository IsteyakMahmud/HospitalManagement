using Hospital.Training.Entities;
using Microsoft.EntityFrameworkCore;
using Registration.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Context
{
    public class TrainingContext : DbContext, ITrainingContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasKey(cs => new { cs.PatientId, cs.DoctorId, cs.TestId });

            modelBuilder.Entity<Appointment>()
                .HasOne(cs => cs.Doctor)
                .WithMany(c => c.AssignedPatient)
                .HasForeignKey(cs => cs.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(cs => cs.Patient)
                .WithMany(c => c.AssignedDoctors)
                .HasForeignKey(cs => cs.PatientId);

                base.OnModelCreating(modelBuilder);
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }


    }
}
