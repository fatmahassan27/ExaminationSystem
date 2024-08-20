﻿// <auto-generated />
using System;
using ExaminationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExaminationSystem.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240309174613_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsInstructorId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseId", "InstructorsInstructorId");

                    b.HasIndex("InstructorsInstructorId");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsStudentId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("DepartmentInstructor", b =>
                {
                    b.Property<int>("DepartmentsDepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsInstructorId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentsDepartmentId", "InstructorsInstructorId");

                    b.HasIndex("InstructorsInstructorId");

                    b.ToTable("DepartmentInstructor");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CourseHours")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentDesc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<int?>("ExamFinalGrade")
                        .HasColumnType("int");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Include", b =>
                {
                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentAnswer")
                        .HasColumnType("int");

                    b.HasKey("ExamId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Includes");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("InstructorDegree")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("InstructorSalary")
                        .HasColumnType("int");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.MultipleChoice", b =>
                {
                    b.Property<int>("MultipleChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MultipleChoiceId"));

                    b.Property<string>("MultipleChoiceTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("MultipleChoiceId");

                    b.HasIndex("QuestionId");

                    b.ToTable("MultipleChoices");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionGrade")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionModelAnswer")
                        .HasColumnType("int");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("CourseId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleDesc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmenttId")
                        .HasColumnType("int");

                    b.Property<string>("StudentAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentImg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmenttId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserFirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserLastName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExaminationSystem.DAL.Entities.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsInstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExaminationSystem.DAL.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DepartmentInstructor", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExaminationSystem.DAL.Entities.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsInstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Exam", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Include", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Exam", "Exam")
                        .WithMany("Includes")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExaminationSystem.DAL.Entities.Question", "Question")
                        .WithMany("Includes")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Instructor", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.User", "User")
                        .WithOne("Instructor")
                        .HasForeignKey("ExaminationSystem.DAL.Entities.Instructor", "InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.MultipleChoice", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Question", "Question")
                        .WithMany("MultipleChoices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Question", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Course", "Course")
                        .WithMany("Questions")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Student", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmenttId");

                    b.HasOne("ExaminationSystem.DAL.Entities.User", "Stu")
                        .WithOne("Student")
                        .HasForeignKey("ExaminationSystem.DAL.Entities.Student", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Stu");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.User", b =>
                {
                    b.HasOne("ExaminationSystem.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Course", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Exam", b =>
                {
                    b.Navigation("Includes");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Question", b =>
                {
                    b.Navigation("Includes");

                    b.Navigation("MultipleChoices");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.Student", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("ExaminationSystem.DAL.Entities.User", b =>
                {
                    b.Navigation("Instructor");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
