using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = GetDepartmentsWithMoreThan5Employees(context);
            Console.WriteLine(result);
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var departaments = context
                .Departments
                .Where(d => d.Employees.Count() > 5)
                .Select(d => new
                {
                    d.Name,
                    d.Manager,
                    Employees = d.Employees
                })
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .ToList();

            foreach (var departament in departaments)
            {
                sb.AppendLine($"{departament.Name} - {departament.Manager.FirstName} {departament.Manager.LastName}");
                foreach (var employee in departament.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}