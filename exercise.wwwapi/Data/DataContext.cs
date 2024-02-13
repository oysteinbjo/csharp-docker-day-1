﻿using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id=1,
                FirstName="Peder",
                LastName="Anton",
                DateOfBirth=DateTime.UtcNow,
                CourseTitle="C#",
                AverageGrade=3.0d,
            },
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 2,
                FirstName = "Guiseppe",
                LastName = "Garibaldi",
                DateOfBirth = DateTime.UtcNow,
                CourseTitle = "Java",
                AverageGrade = 4.0d,
            },

            modelBuilder.Entity<Student>().HasKey(x => x.Id);  
            modelBuilder.Entity<Student>()
                        .HasOne(x => x.Course)
                        .WithMany(c => c.Students)
                        .HasForeignKey(x => x.CourseId);
            modelBuilder.Entity<Course>().HasKey(x => x.Id);

            modelBuilder.Entity<Course>().Navigation(c => c.Students).AutoInclude();
            modelBuilder.Entity<Student>().Navigation(s => s.Course).AutoInclude();

            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
