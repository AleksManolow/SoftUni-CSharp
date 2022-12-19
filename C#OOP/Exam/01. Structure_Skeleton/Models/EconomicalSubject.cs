using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        public EconomicalSubject(int id, string name)
            : base(id, name, 1.0)
        {
        }
    }
}
