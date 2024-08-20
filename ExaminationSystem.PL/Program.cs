using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.Repository;
using ExaminationSystem.DAL;
using ExaminationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Session
            builder.Services.AddSession();

            //Scope
            builder.Services.AddScoped(typeof(IInstructorRepo), typeof(InstructorRepo));
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IReportRep,ReportRep>();

            builder.Services.AddScoped<ILoginRepo, LoginManagerRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<IPreExamRepo, PreExamRepo>();
            builder.Services.AddScoped<IExam, ExamRepo>();
            builder.Services.AddScoped<IExamRep, ExamRep>();
            builder.Services.AddScoped(typeof(IGenerateExamRepo), typeof(GenerateExamRepo));
            builder.Services.AddScoped(typeof(IGetResultRepo), typeof(GetExamResultRepo));
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();










            string connectionString = builder.Configuration.GetConnectionString("MyConnection");
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(a=>a.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
