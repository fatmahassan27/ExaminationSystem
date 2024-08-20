using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.ModelVM.GenerateExamVM;
using ExaminationSystem.DAL.Context;
using ExaminationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public class GenerateExamRepo : IGenerateExamRepo
    {
        private readonly ApplicationDbContext Db;

        public GenerateExamRepo(ApplicationDbContext Db)
        {
            this.Db = Db;

        }
        public void Generate(GenerateExamVM generateExam)
        {
            var Course = Db.Courses.Where(a => a.CourseId == generateExam.CourseID).FirstOrDefault();
            foreach (var item in generateExam.StId)
            {
                if (item.IsSelected)
                {
                    Db.Database.ExecuteSql($"Exec [st_generateExams] {Course.CourseName},{generateExam.TrueOrFalseCounnt},{generateExam.OtherQuestionCount}");
                    var Exam = Db.Exams.OrderByDescending(a => a.ExamId).FirstOrDefault();

                    Db.Database.ExecuteSql($"Exec [UpdateExams] {Exam.ExamId},{Exam.ExamName},{null},{item.StudentID}");
                }

            }
        }

        public GenerateExamVM Get(int id)
        {
            GenerateExamVM generateExam = new GenerateExamVM() { CourseID = id };
            generateExam.StId = new List<StudentGenerateExamVM>();
            var Courses = Db.Courses.Include(a => a.Students).Where(c => c.CourseId == id).FirstOrDefault();
            var Students = Courses.Students.ToList();
            foreach (var student in Students)
            {
                var user = Db.Users.Where(a => a.UserId == student.StudentId).FirstOrDefault();
                var StudentGenerateExamVM = new StudentGenerateExamVM() { StudentID = student.StudentId, StudentName = user.UserFirstName + user.UserLastName };
                generateExam.StId.Add(StudentGenerateExamVM);
            }
            return generateExam;
        }

    }
    }

