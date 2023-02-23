using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();    
            string result = GetEmployeesInPeriod(context);
            Console.WriteLine(result);
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Projects.Any(ep => ep.StartDate.Year >= 2001 && ep.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.Projects.Select(ep => new
                    {
                        ProjectName = ep.Name,
                        ProjectStartDate = ep.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        ProjectEndDate = ep.EndDate.HasValue
                                ? ep.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                : "not finished"
                    }).ToArray()
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var ep in employee.Projects)
                {
                    sb.AppendLine($"--{ep.ProjectName} - {ep.ProjectStartDate} - {ep.ProjectEndDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}