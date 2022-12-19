using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private readonly List<int> coveredExams;
        private IUniversity university;

        public Student(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.coveredExams = new List<int>();
            this.University = null;
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        }
        public IReadOnlyCollection<int> CoveredExams => coveredExams;

        public IUniversity University
        {
            get { return university; }
            private set { university = value; }
        }

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university;
        }
    }
}
