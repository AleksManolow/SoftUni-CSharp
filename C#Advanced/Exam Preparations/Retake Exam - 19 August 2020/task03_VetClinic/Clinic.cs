using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public int Capacity { get; set; }
        private List<Pet> date;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            this.date = new List<Pet>();
        }
        public void Add(Pet pet)
        {
            if (this.date.Count + 1 <= Capacity)
            {
                date.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = this.date.SingleOrDefault(x => x.Name == name);
            if (pet != null)
            {
                this.date.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            return this.date.SingleOrDefault(x => x.Name == name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            if (this.date.Count == 0)
            {
                return null;
            }

            return this.date.OrderByDescending(x => x.Age).First();
        }

        public int Count => this.date.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in this.date)
            {
                sb.AppendLine(pet.ToString());
            }
            return sb.ToString();
        }
    
    }
}
