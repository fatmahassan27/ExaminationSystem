using ExaminationSystem.BL.Interface;
using ExaminationSystem.BL.Mapping;
using ExaminationSystem.BL.ModelVM.DepartmentVM;
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
    public class DepartmentRepo: IDepartmentRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DepartmentMapper _departmentMapper;

        public DepartmentRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _departmentMapper = new DepartmentMapper();
        }
        public List<DepartmentVM> GetAllDepartments()
        {
            var department = _applicationDbContext.Departments.Include(b => b.Students).Include(d => d.Instructors).ToList();
            return _departmentMapper.Mapp(department);


        }
        public DepartmentVM GetById(int id)
        {
            var department = _applicationDbContext.Departments.Include(a => a.Students).Include(a =>a.Instructors).Where(a => a.DepartmentId == id).FirstOrDefault();
            return _departmentMapper.Mapp(department);
        }
        public void AddDepartment(Department department)
        {
            _applicationDbContext.Database.ExecuteSql($"Exec [st_insertIntoDepartment] {department.DepartmentName}, {department.DepartmentDesc}");
           

        }
        public void UpdateDepartment(DepartmentVM department)
        {
            _applicationDbContext.Database.ExecuteSql($"Exec [st_updateDepartment] {department.DeptId}, {department.DeptName}, {department.DeptDesc}");
            
        }

        public void DeleteDepartment(DepartmentVM department)
        {
            _applicationDbContext.Database.ExecuteSql($"Exec [st_deleteFromDepartment] {department.DeptId}");
            
        }


    }
}
