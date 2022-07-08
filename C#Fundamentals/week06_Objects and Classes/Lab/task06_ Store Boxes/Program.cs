using System;
using System.Collections.Generic;

namespace task06__Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                Box temp = new Box();
                temp.serialNumber = int.Parse(input[0]);
                temp.item = new Item(input[1], double.Parse(input[2]));
                temp.itemQuantity = double.Parse(input[3]);

                boxes.Add(temp);
                input = Console.ReadLine().Split();
            }


            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = i; j < boxes.Count; j++)
                {
                    if (boxes[i].priceOfBox < boxes[j].priceOfBox)
                    {
                        Box temp = boxes[i];
                        boxes[i] = boxes[j];
                        boxes[j] = temp;
                    }
                }
            }

            foreach (var box in boxes)
            {
                box.printBox();
            }
        }
    }
    class Item
    {
        public Item(string _name, double _price)
        {
            name = _name;
            price = _price;
        }
        public string name { get; set; }
        public double price { get; set; }
    }
    class Box
    {
        public int serialNumber { get; set; }
        public Item item { get; set; }
        public double itemQuantity { get; set; }
        public double priceOfBox {
            get
            {
                return this.itemQuantity * this.item.price;
            } 
        }
        public void printBox()
        {
            Console.WriteLine(this.serialNumber);
            Console.WriteLine($"-- {this.item.name} - ${this.itemQuantity:F2}: {this.item.price}");
            Console.WriteLine($"-- ${this.priceOfBox:F2}");
        }
    }
}
