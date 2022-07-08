using System;
using System.Collections.Generic;

namespace task04_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int numberOfStudents = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split();
                Student student = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(student);
            }
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = i; j < students.Count; j++)
                {
                    if (students[i].Grade < students[j].Grade)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FisrtName} {student.LastName}: {student.Grade:F2}");
            }
        }
    }
    class Student
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student()
        {
            this.FisrtName = null;
            this.LastName = null;
            this.Grade = 0;
        }
        public Student(string fisrtName, string lastName, double grade)
        {
            this.FisrtName = fisrtName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }
}
