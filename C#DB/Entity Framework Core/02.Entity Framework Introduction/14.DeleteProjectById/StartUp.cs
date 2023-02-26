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
            string result = DeleteProjectById(context);
            Console.WriteLine(result);
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Project projectToDelete = context
                .Projects.Find(2);

            var referencedProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId)
                .ToList();

            context.EmployeesProjects.RemoveRange(referencedProjects);
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            string[] projectNames = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            foreach (var p in projectNames)
            {
                output.AppendLine(p);
            }

            return output.ToString().TrimEnd();
        }
    }
}