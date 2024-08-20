using ExaminationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.DAL.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SABREEN\\SQLEXPRESS;Initial Catalog=ITI_Project;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }

        public virtual DbSet<Include> Includes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<MultipleChoice> MultipleChoices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Include>().HasKey(a => new { a.ExamId, a.QuestionId });


            modelBuilder.Entity<Student>()
                .HasOne(s => s.Stu)
                .WithOne(u => u.Student)
                .HasPrincipalKey<User>(u => u.UserId); 

            modelBuilder.Entity<Instructor>()
           .HasOne(i => i.User)
           .WithOne(u => u.Instructor)
           .HasPrincipalKey<User>(u => u.UserId); 


        }
    }
}
