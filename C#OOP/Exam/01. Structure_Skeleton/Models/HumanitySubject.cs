using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {
        public HumanitySubject(int id, string name)
            : base(id, name, 1.15)
        {
        }
    }
}
