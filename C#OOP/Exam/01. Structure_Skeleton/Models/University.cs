using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private readonly List<int> requiredSubjects;

        public University(int id, string name, string category, int capacity, List<int> requiredSubjects)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Capacity = capacity;
            this.requiredSubjects = requiredSubjects;
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
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }
        public string Category
        {
            get { return category; }
            private set 
            {
                string convertedCategory = value.ToLower();
                if ("technical" != convertedCategory && "economical" != convertedCategory && "humanity" != convertedCategory)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value;
            }
        }
        public int Capacity
        {
            get { return capacity; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                capacity = value;
            }
        }
        public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects;
    }
}
