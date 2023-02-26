using SoftUni.Data;
using SoftUni.Models;
using System.Linq;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = RemoveTown(context);
            Console.WriteLine(result);
        }
        public static string RemoveTown(SoftUniContext context)
        {
            Town townForDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var address = context.Addresses.Where(a => a.Town.Name == "Seattle").ToList();

            foreach (var employee in context.Employees)
            {
                if (address.Any(a => a.AddressId == employee.AddressId))
                {
                    employee.AddressId = null;
                }
            }

            int numberOfDeletedAddresses = address.Count;

            context.Addresses.RemoveRange(address);
            context.Towns.Remove(townForDelete);

            context.SaveChanges();
            return $"{numberOfDeletedAddresses} addresses in Seattle were deleted";
        }
    }
}