using System;
using System.Collections.Generic;
using System.Linq;

namespace task06_Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades.Add(student, new List<double>());
                }
                studentsGrades[student].Add(grade);
            }
            foreach (var student in studentsGrades)
            {
                if (Queryable.Average(student.Value.AsQueryable()) >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {Queryable.Average(student.Value.AsQueryable()):F2}");
                }
            }

        }
    }
}
