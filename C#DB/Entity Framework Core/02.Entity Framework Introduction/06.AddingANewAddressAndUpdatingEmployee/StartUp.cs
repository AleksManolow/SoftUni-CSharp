using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();    
            string result = AddNewAddressToEmployee(context);
            Console.WriteLine(result);
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            StringBuilder sb = new StringBuilder();
            string[] addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();
            foreach (var a in addresses)
            {
                sb.AppendLine(a);
            }

            return sb.ToString().TrimEnd();
        }
    }
}