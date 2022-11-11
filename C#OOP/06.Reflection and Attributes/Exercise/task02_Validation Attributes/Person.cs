using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        [MyRequired]
        public string Name { get; set; }
        [MyRange(1,99)]
        public int Age { get; set; }
    }
}
