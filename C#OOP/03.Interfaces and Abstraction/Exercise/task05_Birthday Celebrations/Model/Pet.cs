using System;
using System.Collections.Generic;
using System.Text;


namespace task05_Birthday_Celebrations
{
    public class Pet:IBirthdate
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
