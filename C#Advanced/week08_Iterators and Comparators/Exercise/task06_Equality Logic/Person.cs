using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace task06_Equality_Logic
{
    public class Person:IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            int name = this.Name.CompareTo(other.Name);
            if (name != 0)
            {
                return name;
            }
            return this.Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            return this.Name == person.Name && this.Age == person.Age;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
