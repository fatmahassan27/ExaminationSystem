using ExaminationSystem.BL.ModelVM.DepartmentVM;
using ExaminationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.BL.Mapping
{
    public class DepartmentMapper
    {
        public List<DepartmentVM> Mapp(List<Department> departments)
        {
            List<DepartmentVM> departmentVMs = new List<DepartmentVM>();

            foreach (Department department in departments)
            {
                var departmentViewModel = new DepartmentVM()
                {
                    DeptId = department.DepartmentId,
                    DeptDesc = department.DepartmentDesc,
                    DeptName = department.DepartmentName,
                    Instructors = department.Instructors,
                    Students = department.Students,
                    
                };

                departmentVMs.Add(departmentViewModel);
            }


            return departmentVMs;

        }

        public DepartmentVM Mapp(Department department)
        {
            var dep=new DepartmentVM()
            {
                DeptId = department.DepartmentId,
                DeptDesc = department.DepartmentDesc,
                
                DeptName = department.DepartmentName,
                Instructors = department.Instructors,
               
                Students = department.Students,
                

            };
            return dep;
        }

        
    }
}
