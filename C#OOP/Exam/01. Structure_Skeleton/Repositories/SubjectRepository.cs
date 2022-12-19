﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private readonly List<ISubject> subjects;

        public SubjectRepository()
        {
            this.subjects = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => subjects;

        public void AddModel(ISubject model)
        {
            subjects.Add(model);
        }

        public ISubject FindById(int id)
        {
            return subjects.FirstOrDefault(s => s.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return subjects.FirstOrDefault(s => s.Name == name);
        }
    }
}
