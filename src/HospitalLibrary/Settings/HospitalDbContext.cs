﻿using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room() { RoomId = 1, Number = "101A", Floor = 1 },
                new Room() { RoomId = 2, Number = "204", Floor = 2 },
                new Room() { RoomId = 3, Number = "305B", Floor = 3 }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, Name = "Pera", Surname = "Peric" },
                new Patient() { Id = 2, Name = "Marko", Surname = "Markovic" },
                new Patient() { Id = 3, Name = "Aleksa", Surname = "Aleksic" }
            );

            modelBuilder.Entity<Specialization>().HasData(
               new Specialization() { SpecializationId = 1, Name = "Anesthesiology" },
               new Specialization() { SpecializationId = 2, Name = "Dermatology" },
               new Specialization() { SpecializationId = 3, Name = "Family medicine" }
           );

            modelBuilder.Entity<Doctor>().HasData(
               new Doctor() { DoctorId = 1, Name = "Ognjen", Surname = "Nikolic", SpecializationId = 3, RoomId = 1 }
               /*new Doctor() { Id = 2, Name = "Mika", Surname = "Mikic", SpecializationId = 3, RoomId = 2 },
               new Doctor() { Id = 3, Name = "Aleksa", Surname = "Santic", SpecializationId = 3, RoomId = 1 }*/
           );

            modelBuilder.Entity<Appointment>().HasData(
               new Appointment() { AppointmentId = 1, DateTime = System.DateTime.Now, DoctorId = 1, PatientId = 1 }
           );
            base.OnModelCreating(modelBuilder);
        }
    }
}
