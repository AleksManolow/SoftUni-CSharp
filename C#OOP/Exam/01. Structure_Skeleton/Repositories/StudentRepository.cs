using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly List<IStudent> students;

        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => students;

        public void AddModel(IStudent model)
        {
            students.Add(model);
        }

        public IStudent FindById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] names = name.Split(" ");
            return students.FirstOrDefault(s => s.FirstName == names[0] && s.LastName == names[1]);
        }
    }
}
