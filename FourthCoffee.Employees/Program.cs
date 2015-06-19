using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.Employees
{
    class Program
    {
        private static FourthCoffeeEntities DBContext;
        static void Main(string[] args)
        {
            DBContext = new FourthCoffeeEntities();

            GetListOfEmployees();

            Console.WriteLine("------------------------");
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
            int ageInYears = (int) (difference.Days/365.25);
            return ageInYears;
        }
    }
}
