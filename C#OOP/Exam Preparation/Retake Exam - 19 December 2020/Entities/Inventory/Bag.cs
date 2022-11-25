using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {   
        private readonly List<Item> items;
        public Bag(int capacity = 100)
        {
            Capacity= capacity;
            items = new List<Item>();

        }
        public int Capacity { get; set; }

        public int Load => Items.Sum(w => w.Weight);

        public IReadOnlyCollection<Item> Items 
            => items;

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }
        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            this.items.Remove(item);
            return item;
        }
    }
}
