using SpaceStation.Models.Bags.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private List<string> item;
        public Backpack()
        {
            this.item = new List<string>();
        }
        public ICollection<string> Items => item;
    }
}
