using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private readonly List<Renovator> renovators;

        public string Name { get; set; }
        public int NeededRenovatorsperty { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public  Catalog(string name, int neededRenovatorsperty, string project)
        {
            Name = name;
            NeededRenovatorsperty = neededRenovatorsperty;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (Count == NeededRenovatorsperty)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovatorToRemove = renovators.FirstOrDefault(x => x.Name == name);
            if (renovatorToRemove == null) return false;
            renovators.Remove(renovatorToRemove);
            return true;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(r => r.Type == type);
        }
        public Renovator HireRenovator(string name)
        {
            var renovatorToHire = renovators.FirstOrDefault(r => r.Name == name);
            if (renovatorToHire != null)
            {
                renovatorToHire.Hired = true;
            }

            return renovatorToHire;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.FindAll(x => x.Days >= days).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
