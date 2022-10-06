using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        
        public void Add(Car car)
        {
            if (this.data.Count + 1 <= Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = this.data.SingleOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car != null)
            {
                this.data.Remove(car);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (this.data.Count == 0)
            {
                return null;
            }

            return this.data.OrderByDescending(x => x.Year).First();
        }
        public Car GetCar(string manufacturer, string model)
        {
            return this.data.SingleOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int Count => this.data.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}
