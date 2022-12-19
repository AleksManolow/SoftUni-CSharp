using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        public TechnicalSubject(int id, string name)
            : base(id, name, 1.3)
        {
        }
    }
}
