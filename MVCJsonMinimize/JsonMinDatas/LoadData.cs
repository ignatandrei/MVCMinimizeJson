using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMinDatas
{
    public class LoadData
    {
        static Dictionary<string, string> dEmp;
        static Dictionary<string, string> dDep;
        static LoadData()
        {
            dEmp = new Dictionary<string, string>(); 
            dEmp.Add("F", "FirstName");
            dEmp.Add("L", "LastName");
            dEmp.Add("Lo", "Login");
            dEmp.Add("D", "DateOfBirth");
            dEmp.Add("M", "ManagerName");
            Utils<Employee, ESmall>.CreateMap(dEmp);


            dDep = new Dictionary<string, string>();
            dDep.Add("I", "IdDepartment");
            dDep.Add("D", "NameDepartment");
            dDep.Add("E", "Employees");

            Utils<Department, DSmall>.CreateMap(dDep);
        }
        
        public List<Department> LoadAllDepartments()
        {
            var ret = new List<Department>();
            for (int depNr = 0; depNr < 99; depNr++)
            {
                var d = new Department();
                d.NameDepartment = "Department " + depNr;
                d.IdDepartment = depNr;
                //loading random number of employees
                var r = new Random(DateTime.Now.Millisecond);
                var nr = r.Next(1, 10);
                for (int eNr = 0; eNr < nr; eNr++)
                {
                    Employee e = new Employee();
                    e.FirstName = string.Format("Dep {0} first name {1}", depNr, eNr);
                    e.LastName = string.Format("Dep {0} last name {1}", depNr, eNr);
                    e.DateOfBirth = new DateTime(1970, r.Next(1, 12), r.Next(1, 26));
                    e.ManagerName = string.Format("Dep {0} manager {1}", depNr, eNr);
                    d.Employees.Add(e);

                }
                ret.Add(d);
            }
            return ret;
        }
        public List<DSmall> Minimize(List<Department> d)
        {
            

            return AutoMapper.Mapper.Map<List<Department>, List<DSmall>>(d);

        }
    }
}
