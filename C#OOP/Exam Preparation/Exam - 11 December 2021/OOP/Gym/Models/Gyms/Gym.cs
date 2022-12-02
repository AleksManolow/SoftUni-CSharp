using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public double EquipmentWeight => equipment.Sum(e => e.Weight);
        
        public ICollection<IEquipment> Equipment => equipment;
        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == Athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }
        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }
        public void Exercise()
        {
            foreach (var athlet in athletes)
            {
                athlet.Exercise();
            }
        }
        public string GymInfo()
        {
            var athletesToString = athletes.Count == 0 ? "No athletes" : string.Join(", ", athletes.Select(x => x.FullName));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletesToString}");
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");
            return sb.ToString().TrimEnd();
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
