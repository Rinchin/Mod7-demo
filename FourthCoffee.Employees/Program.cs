using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.Employees
{
    class FullName
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }

    class Program
    {
        private static FourthCoffeeEntities DBContext;
        static void Main(string[] args)
        {
            DBContext = new FourthCoffeeEntities();

            #region Select And Change Data In DataBase
            //GetListOfEmployees();

            //Console.WriteLine("------------------------");

            //var emp = DBContext.Employees.First(e => e.LastName == "Prescott");
            //if (emp != null)
            //{
            //    emp.LastName = "Forsyth";
            //}
            //DBContext.SaveChanges(); //save all changes to datebase

            //GetListOfEmployees();
            //Console.ReadLine();
            #endregion

            #region Query Data from Database
            //select all date
            IQueryable<Employee> emps1 = from e in DBContext.Employees
                                         select e;

            //Filtering data by row
            string _LastName = "Prescott";
            IQueryable<Employee> emps2 = from e in DBContext.Employees
                                         where e.LastName == _LastName
                                         select e;

            //Filtering Data By Column
            //Returned data is stored in Strongly typed IQueriable<Type>
            IQueryable<FullName> names = from e in DBContext.Employees
                                         select new FullName() { Firstname = e.FirstName, Surname = e.LastName };

            foreach (var fullName in names)
            {
                Console.WriteLine("{0} {1}", fullName.Firstname, fullName.Surname);
            }
            //Console.ReadLine();


            //Filtering Data by Column
            //Returned data is stored in Anonymous Type
            var names1 = from e in DBContext.Employees
                         select new { e.FirstName, e.LastName };

            foreach (var fullName in names)
            {
                Console.WriteLine("{0} {1}", fullName.Firstname, fullName.Surname);
            }
            //Console.ReadLine();

            //Grouping Data
            var emps = from e in DBContext.Employees
                       group e by e.JobTitle
                           into eGroup
                           select new
                           {
                               Job = eGroup.Key,
                               Names = eGroup
                           };

            foreach (var emp in emps)
            {
                Console.WriteLine("{0} {1}", emp.Job.Value, emp.Names);

            }
            #endregion

        }

        private static void GetListOfEmployees()
        {
            foreach (Employee employee in DBContext.Employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
            }
        }
    }

    public partial class Employee
    {
        public int GetAge()
        {
            DateTime DOB = (DateTime)DateOfBirth;
            TimeSpan difference = DateTime.Now.Subtract(DOB);
            int ageInYears = (int)(difference.Days / 365.25);
            return ageInYears;
        }
    }
}
