using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public int Capacity { get; set; }   
        public int Count { get; set; }
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if (students.Count + 1 <= Capacity)
            {
                students.Add(student);
                Count++;
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.SingleOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student != null)
            {
                Count--;
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            if (students.Where(x => x.Subject == subject).Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var item in students.Where(x => x.Subject == subject))
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
                return sb.ToString();
            }
            return "No students enrolled for the subject";
        }
        public int GetStudentsCount() => students.Count;
        public Student GetStudent(string firstName, string lastName)
        {
            return students.SingleOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
