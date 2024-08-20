using ExaminationSystem.BL.ModelVM.DepartmentVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Interface
{
    public interface IDepartmentRepo
    {
        public List<DepartmentVM> GetAllDepartments();
       public  DepartmentVM GetById(int id);
       public  void AddDepartment(Department department);
        public void UpdateDepartment(DepartmentVM department);

       public void DeleteDepartment(DepartmentVM department);
    }
}
