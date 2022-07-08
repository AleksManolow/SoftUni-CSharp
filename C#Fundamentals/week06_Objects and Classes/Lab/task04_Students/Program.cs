using System;
using System.Collections.Generic;

namespace task04_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                Student student = new Student();
                student.FisrtName = input[0];
                student.LastName = input[1];
                student.Age = int.Parse(input[2]);
                student.HomeTown = input[3];

                students.Add(student);

                input = Console.ReadLine().Split();
            }

            string town = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FisrtName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    public class Student
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
