using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();
            string result = GetAddressesByTown(context);
            Console.WriteLine(result);
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var addresses = context
                .Addresses
                .Select( a => new
                {
                    a.AddressText,
                    AddressTown = a.Town.Name,
                    CountEmployees = a.Employees.Count()
                })
                .OrderByDescending(a => a.CountEmployees)
                .ThenBy(a => a.AddressTown)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses) 
            {
                sb.AppendLine($"{address.AddressText}, {address.AddressTown} - {address.CountEmployees} employees");
            }
            return sb.ToString().TrimEnd();
        }
    }
}