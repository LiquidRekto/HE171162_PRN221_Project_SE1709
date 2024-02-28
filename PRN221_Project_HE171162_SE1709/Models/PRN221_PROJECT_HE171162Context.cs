using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRN221_Project_HE171162_SE1709.Models
{
    public partial class PRN221_PROJECT_HE171162Context : DbContext
    {
        public PRN221_PROJECT_HE171162Context()
        {
        }

        public PRN221_PROJECT_HE171162Context(DbContextOptions<PRN221_PROJECT_HE171162Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Instructor> Instructors { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<TeachingSession> TeachingSessions { get; set; } = null!;
        public virtual DbSet<TimeSlot> TimeSlots { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                              .SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("WebCnn"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("Building");

                entity.Property(e => e.Alias)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Code)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("Instructor");

                entity.Property(e => e.Alias)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasIndex(e => new { e.Building, e.Number }, "uk_roomname")
                    .IsUnique();

                entity.Property(e => e.Number)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.BuildingNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.Building)
                    .HasConstraintName("FK__Room__Building__2F10007B");
            });

            modelBuilder.Entity<TeachingSession>(entity =>
            {
                entity.ToTable("TeachingSession");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.TeachingSessions)
                    .HasForeignKey(d => d.Class)
                    .HasConstraintName("FK__TeachingS__Class__33D4B598");

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany(p => p.TeachingSessions)
                    .HasForeignKey(d => d.Course)
                    .HasConstraintName("FK__TeachingS__Cours__34C8D9D1");

                entity.HasOne(d => d.InstructorNavigation)
                    .WithMany(p => p.TeachingSessions)
                    .HasForeignKey(d => d.Instructor)
                    .HasConstraintName("FK__TeachingS__Instr__35BCFE0A");

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.TeachingSessions)
                    .HasForeignKey(d => d.Room)
                    .HasConstraintName("FK__TeachingSe__Room__31EC6D26");

                entity.HasOne(d => d.TimeSlotNavigation)
                    .WithMany(p => p.TeachingSessions)
                    .HasForeignKey(d => d.TimeSlot)
                    .HasConstraintName("FK__TeachingS__TimeS__32E0915F");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
