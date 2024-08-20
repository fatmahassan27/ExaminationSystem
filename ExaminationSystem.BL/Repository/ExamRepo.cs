using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.Mapping;
using ExaminationSystem.BL.ModelVM.Courses;
using ExaminationSystem.BL.ModelVM.ExamVM;
using ExaminationSystem.BL.ViewModels.ExamVM;
using ExaminationSystem.DAL.Context;
using ExaminationSystem.DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Repository
{
    public class ExamRepo:IExam
    {
        private readonly ApplicationDbContext Db;
        private readonly ExamMapper examMapper;
        public ExamRepo(ApplicationDbContext _db)
        {
            Db = _db;
            examMapper = new ExamMapper();
        }
        public List<GetAllExamVM> GetAllExam()

        {
            var examList = Db.Exams.Include(a => a.Student).ThenInclude(a => a.Stu).ToList();

            return examMapper.Map(examList);
        }

        public GetExamByIdVM getExamById(int id)
        {
            var ExamData = Db.Exams.Include(a => a.Student).ThenInclude(a => a.Stu).SingleOrDefault(a => a.ExamId == id);

            if (ExamData == null)
            {
                return null;
            }
            return examMapper.Map(ExamData);

        }
        public IEnumerable<GetExamByIdVM> GetExamById(int id)

        {
            var Data = Db.Includes.Where(i => i.ExamId == id).Include(i => i.Question.MultipleChoices).ToList();
            return examMapper.Map(Data);
        }

        public void DeleteExam(int id)
        {
            Db.Database.ExecuteSqlRaw($"DeleteFromExam {id}");
        }

 
    }
}
