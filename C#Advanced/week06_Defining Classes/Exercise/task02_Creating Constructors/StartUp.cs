using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Aleks", 21);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
