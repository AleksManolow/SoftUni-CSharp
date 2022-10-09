using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BakeryOpenning
{
    public class Bakery
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        private List<Employee> employees;

        public int Count { get; set; }

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.employees = new List<Employee>();
            this.Count = 0; 
        }

        public void Add(Employee employee)
        {
            if (employees.Count + 1 <= Capacity)
            {
                Count++;
                employees.Add(employee);   
            }
        }

        public bool Remove(string name)
        {
            Employee employee = employees.SingleOrDefault(x => x.Name == name);
            if (employee != null)
            {
                Count--;
                employees.Remove(employee);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return employees.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return employees.SingleOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString();
        }
    }
}
