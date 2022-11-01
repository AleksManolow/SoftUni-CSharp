using System;
using System.Collections.Generic;
using task08_Collection_Hierarchy.Model;

namespace task08_Collection_Hierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addResult1 = new List<int>();
            List<int> addResult2 = new List<int>();
            List<int> addResult3 = new List<int>();

            string[] items = Console.ReadLine().Split();

            foreach (var item in items)
            {
                addResult1.Add(addCollection.Add(item));
                addResult2.Add(addRemoveCollection.Add(item));
                addResult3.Add(myList.Add(item));
            }

            List<string> removeResult1 = new List<string>();
            List<string> removeResult2 = new List<string>();

            int itemsToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsToRemove; i++)
            {
                removeResult1.Add(addRemoveCollection.Remove());
                removeResult2.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', addResult1));
            Console.WriteLine(string.Join(' ', addResult2));
            Console.WriteLine(string.Join(' ', addResult3));
            Console.WriteLine(string.Join(' ', removeResult1));
            Console.WriteLine(string.Join(' ', removeResult2));
        }
    }
}
