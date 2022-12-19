using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;

        protected Subject(int id, string name, double rate)
        {
            this.Id = id;
            this.Name = name;
            this.Rate = rate;
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }
        public double Rate
        {
            get { return rate; }
            private set { rate = value; }
        }
    }
}
