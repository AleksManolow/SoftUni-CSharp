using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = GetEmployee147(context);
            Console.WriteLine(result);
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee147 = context
                 .Employees
                 .Where(e => e.EmployeeId == 147)
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     e.JobTitle,
                     Projects = e.Projects
                         .Select(ep => new
                         {
                             ep.Name
                         })
                         .OrderBy(ep => ep.Name)
                         .ToArray()
                 })
                 .ToArray();

            foreach (var e in employee147)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var project in e.Projects)
                {
                    sb.AppendLine(project.Name);
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}