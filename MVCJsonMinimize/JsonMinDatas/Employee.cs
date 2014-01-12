using System;
using System.Collections.Generic;
using System.Linq;


namespace JsonMinDatas
{

    public class Department{
        public Department()
        {
            Employees = new List<Employee>();
        }
        public int IdDepartment { get; set; }
        public string NameDepartment { get; set; }
        public List<Employee> Employees { get; set; }



    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login
        {
            get
            {
                return FirstName + "." + LastName;
            }
        }
        public DateTime DateOfBirth { get; set; }

        public string ManagerName { get; set; }


    }


    
}