﻿using ContsoUniversityPressTARpe22.Models;
using Microsoft.EntityFrameworkCore;

namespace ContsoUniversityPressTARpe22.Data
{
    public class SchoolContext: DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options) : base(options)
        { 
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment>Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment>OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable(nameof(Course));
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments"); 
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            

        }
    }
}