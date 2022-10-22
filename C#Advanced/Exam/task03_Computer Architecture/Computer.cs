using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public int Count => this.Multiprocessor.Count;  

        public void Add(CPU cpu)
        {
            if (Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpu = Multiprocessor.SingleOrDefault(x => x.Brand == brand);
            if (cpu == null)
            {
                return false;
            }
            this.Multiprocessor.Remove(cpu);
            return true;
        }
        public CPU MostPowerful()
        {
            double maxFrequency = this.Multiprocessor.Max(x => x.Frequency);
            return this.Multiprocessor.SingleOrDefault(x => x.Frequency == maxFrequency);

        }

        public CPU GetCPU(string brand)
        {
            return this.Multiprocessor.SingleOrDefault(x => x.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var item in Multiprocessor)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
