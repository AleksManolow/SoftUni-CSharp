using System;
using System.Collections.Generic;

namespace task05_Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentsInCourse = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" : ");
            while (input[0] != "end")
            {
                if (!studentsInCourse.ContainsKey(input[0]))
                {
                    studentsInCourse.Add(input[0], new List<string>());
                }
                studentsInCourse[input[0]].Add(input[1]);

                input = Console.ReadLine().Split(" : ");
            }
            foreach (var course in studentsInCourse)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
