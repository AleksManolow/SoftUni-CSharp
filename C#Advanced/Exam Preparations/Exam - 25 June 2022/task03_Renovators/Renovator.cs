using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired = false;

        public Renovator(string name, string type, double rate, int days)
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public double Rate
        {
            get => rate;
            set => rate = value;
        }

        public int Days
        {
            get => days;
            set => days = value;
        }
        public bool Hired
        {
            get => hired;
            set => hired = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {Name}");
            sb.AppendLine($"--Specialty: {Type}");
            sb.AppendLine($"--Rate per day: {Rate} BGN");
            return sb.ToString().TrimEnd();
            
        }
    }
}
