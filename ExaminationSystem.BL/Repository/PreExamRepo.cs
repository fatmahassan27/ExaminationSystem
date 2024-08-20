using ExaminationSystem.BL.Interface;
using ExaminationSystem.DAL.Context;
using ExaminationSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public class PreExamRepo : IPreExamRepo
    {
        private readonly ApplicationDbContext _context;

        public PreExamRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Exam GetExamByStudentId(int? StudentId)
        {
            var Exam = _context.Exams.Where(e => e.StudentId == StudentId).FirstOrDefault();

            return Exam;
        }

        public Student GetStudentById(int? StudentId)
        {

            Student student = _context.Students.Include(s => s.Stu).Include(d => d.Department).Include(c => c.Courses).Where(b => b.StudentId == StudentId).FirstOrDefault();

            return student;

        }

        public Exam GetExamByStudentId(int id)
        {
            var exam = _context.Exams.FirstOrDefault(e => e.StudentId == id);
            return exam;
        }

        public List<Exam> GetExamList(int? StudentId)
        {
            var StudentExamList = _context.Exams.Where(e => e.ExamFinalGrade == null && e.StudentId == StudentId).ToList();
            return StudentExamList;
        }

     
    }
}
