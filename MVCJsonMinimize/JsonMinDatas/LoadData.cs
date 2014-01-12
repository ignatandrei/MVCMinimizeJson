using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMinDatas
{
    public class LoadData
    {
        public static readonly Dictionary<string, string> dEmp;
        public static readonly Dictionary<string, string> dDep;
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


        
        /// <summary>
        /// shameless copy from
        /// http://stackoverflow.com/questions/4616685/how-to-generate-a-random-string-and-specify-the-length-you-want-or-better-gene/7977737#7977737
        /// </summary>
        /// <param name="allowedChars"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="count"></param>
        /// <param name="rng"></param>
        /// <returns></returns>
        private static IEnumerable<string> RandomStrings(int minLength, int maxLength, int count, Random rng, string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")
        {

            char[] chars = new char[maxLength];
            int setLength = allowedChars.Length;

            while (count-- > 0)
            {
                int length = rng.Next(minLength, maxLength + 1);

                for (int i = 0; i < length; ++i)
                {
                    chars[i] = allowedChars[rng.Next(setLength)];
                }

                yield return new string(chars, 0, length);
            }
        }
        static List<string>  RandomName(int count,Random rng){
            return RandomStrings(4, 10, count, rng).ToList();
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
                var names = RandomName(nr*2,r); // * 2 = first name + last name
                for (int eNr = 0; eNr < nr; eNr++)
                {
                    
                    Employee e = new Employee();
                    e.FirstName = string.Format("{0} {1}",depNr , names[eNr *2] );
                    e.LastName = string.Format("{0} {1}", depNr, names[eNr*2+1]);
                    e.DateOfBirth = new DateTime(1970, r.Next(1, 12), r.Next(1, 26));
                    e.ManagerName = string.Format("manager {0}", eNr);
                    d.Employees.Add(e);

                }
                ret.Add(d);
            }
            return ret;
        }
        public static List<DSmall> Minimize(List<Department> d)
        {
            

            return AutoMapper.Mapper.Map<List<Department>, List<DSmall>>(d);

        }
    }
}
