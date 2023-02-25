using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = IncreaseSalaries(context);
            Console.WriteLine(result);

        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services ")
                .OrderBy(employee => employee.FirstName)
                .ThenBy(employee => employee.LastName)
                .ToList();
            foreach (var employee in employees)
            {
                employee.Salary *= (decimal)1.12; 
            }
            context.SaveChanges();
            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} ({employee.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}