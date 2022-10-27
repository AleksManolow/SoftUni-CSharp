using System;
using System.Collections.Generic;
using System.Text;

namespace task04_Border_Control
{
    public class Citizen:IIdentifiable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
    }
}
