using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            this.Price = price;
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }
        public string Size
        {
            get { return size; }
            private set { size = value; }
        }
        public double Price
        {
            get { return price; }
            private set 
            {
                if (this.Size == "Large")
                {
                    this.price = value;
                }
                else if (this.Size == "Middle")
                {
                    this.price = value / 1.5;
                }
                else if (this.Size == "Small")
                {
                    this.price = value / 3;
                }
            }
        }
        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:F2} lv";
        }
    }
}
