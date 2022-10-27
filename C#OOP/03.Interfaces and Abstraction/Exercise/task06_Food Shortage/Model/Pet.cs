using System;
using System.Collections.Generic;
using System.Text;


namespace task06_Food_Shortage
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
