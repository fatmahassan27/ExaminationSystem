using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.Mapping;
using ExaminationSystem.BL.ModelVM.Courses;
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
    public class CourseRepo : ICourseRepo
    {
        private readonly ApplicationDbContext Db;
        private readonly CourseMapper courseMapper;
        public CourseRepo(ApplicationDbContext _db)
        {
            Db = _db;
            courseMapper = new CourseMapper();
        }
        public List<GetALLCourseVM> GetAll()
        {
            var CourseData = Db.Courses.Include(a => a.Instructors).ThenInclude(a => a.User).ToList();
          
            return courseMapper.Map(CourseData);
        }
       public  GetCourseByIDVM getCourseById(int courseid)
        {
            var CourseData = Db.Courses.Include(a => a.Instructors).ThenInclude(a => a.User).SingleOrDefault(a => a.CourseId == courseid);

            if (CourseData == null)
            {
                return null;
            }

            return courseMapper.Map(CourseData);

        }

        public void DeleteCourse(int courseId)
        {
            Db.Database.ExecuteSqlRaw($"EXEC DeleteCourses {courseId}");
        }

        public void EditCourse(int courseId, string courseName, int courseDuration)
        {
            Db.Database.ExecuteSqlRaw("EXEC [dbo].[UpdateCourses] @Course_Name , @Course_Hours , @Crs_ID",
                    new SqlParameter("@Course_Name", courseName),
                    new SqlParameter("@Course_Hours", courseDuration),
                    new SqlParameter("@Crs_ID", courseId));

        }

        public void EditCourse(EditCourseVM model)
        {
            Db.Database.ExecuteSqlRaw("EXEC [dbo].[UpdateCourses] @Course_Name , @Course_Hours , @Crs_ID ",
                    new SqlParameter("@Course_Name", model.CourseName),
                    new SqlParameter("@Course_Hours", model.CourseHours),
                    new SqlParameter("@Crs_ID", model.CourseId));
                   
        }

        public void InsertCourse(string courseName, int courseDuration)
        {
            Db.Database.ExecuteSqlRaw("EXEC [dbo].[InsertIntoCourses] @Course_Name , @Course_Hours",
                    new SqlParameter("@Course_Name", courseName),
                    new SqlParameter("@Course_Hours", courseDuration));
        }

        public void InsertCourse(InsertIntoCourseVM model)
        {
            Db.Database.ExecuteSqlRaw("EXEC [dbo].[InsertIntoCourses] @Course_Name , @Course_Hours ",
                    new SqlParameter("@Course_Name", model.CourseName),
                    new SqlParameter("@Course_Hours", model.CourseHours));

        }
    }
}
