using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people;
        public Family()
        {
            people = new List<Person>();
        }
        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            return people.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }
}
