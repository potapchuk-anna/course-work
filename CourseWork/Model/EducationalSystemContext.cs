using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Model
{
    class EducationalSystemContext:DbContext
    {
        public EducationalSystemContext(DbContextOptions<EducationalSystemContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Host=localhost;Port=5432;Database=EducationalSystem;Username=user;Password=12345;CommandTimeout=1000;Timeout=1000";
                optionsBuilder.UseNpgsql(connectionString)/*.UseSnakeCaseNamingConvention()*/;
            }
        }
        public EducationalSystemContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Type>();

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Id)
                .UseHiLo();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                   .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.Work)
                   .WithOne(p => p.Grade)
                   .HasForeignKey<Grade>(d => d.WorkId);
            });
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id)
                .UseHiLo();

                entity.HasOne(d => d.Class)
                    .WithOne(p => p.Curator)
                    .HasForeignKey<Class>(d => d.CuratorId);

                entity.HasMany(d => d.Subjects)
                .WithOne(p => p.Teacher)
                .OnDelete(DeleteBehavior.Cascade); 


            });
            modelBuilder.Entity<Work>(entity =>
            {
                entity.Property(e => e.Id)
                .UseHiLo();

                entity.HasOne(d => d.Subject)
                     .WithMany(p => p.Works)
                   .HasForeignKey(d => d.SubjectId);
                
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id)
               .UseHiLo();

                entity.Property(e => e.BirthDate)
                 .HasColumnType("date");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId);

                entity.HasMany(e => e.Grades)
                .WithOne(e => e.Student)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id)
                .UseHiLo();

                entity.HasOne(d => d.Curator)
                    .WithOne(p => p.Class)
                    .HasForeignKey<Class>(d => d.CuratorId);

            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id)
                .UseHiLo();

                entity.HasOne(d => d.Teacher)
                .WithMany(p => p.Subjects)
                  .HasForeignKey(d => d.TeacherId);
            });         

        }

    }
}
