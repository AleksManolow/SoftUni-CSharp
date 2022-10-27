using System;
using System.Collections.Generic;
using System.Text;

namespace task06_Food_Shortage
{
    public class Robot:IIdentifiable
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
