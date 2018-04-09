﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Parttime.Models;

namespace Parttime.DAL
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityContext")
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OfficeAssingment> OfficeAssingments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                .MapRightKey("InstructorID")
                .ToTable("CourseInstructor"));

            /*
            modelBuilder.Entity<Instructor>()
                .HasOptional(p => p.OfficeAssingment).WithRequired(p => p.Instructor);
            */

           // modelBuilder.Entity().HasRequired(d => d.Administrator).WithMany().WillCascadeOnDelete(false);
        }

    }
}