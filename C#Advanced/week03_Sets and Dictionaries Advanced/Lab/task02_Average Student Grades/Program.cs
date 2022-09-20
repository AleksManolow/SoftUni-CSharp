using System;
using System.Collections.Generic;
using System.Linq;

namespace task02_Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,List<decimal>> studentGrades = new Dictionary<string,List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string studentName = input[0];
                decimal studentGrede = decimal.Parse(input[1]);
                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades.Add(studentName, new List<decimal>());
                }
                studentGrades[studentName].Add(studentGrede);
            }
            foreach (var student in studentGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var studentGrede in student.Value)
                    Console.Write($"{studentGrede:f2} ");
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
