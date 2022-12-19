using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) && subjectType != nameof(EconomicalSubject) && subjectType != nameof(HumanitySubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            ISubject subject = null;
            switch (subjectType)
            {
                case nameof(TechnicalSubject):
                    subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
                    break;
                case nameof(EconomicalSubject):
                    subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
                    break;
                case nameof(HumanitySubject):
                    subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
                    break;
            }
            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> convertedRequiredSubjects = new List<int>();
            foreach (var subject in requiredSubjects)
            {
                convertedRequiredSubjects.Add(subjects.FindByName(subject).Id);
            }
            IUniversity university = new University(universities.Models.Count + 1,universityName, category, capacity, convertedRequiredSubjects);
            universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name); 
        }

        public string AddStudent(string firstName, string lastName)
        {
            
            if (students.FindByName(firstName + " " + lastName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            IStudent student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            ISubject subject = subjects.FindById(subjectId);
            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            
            if (student.CoveredExams.Contains(subject.Id))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }
            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] splitStudentNames = studentName.Split(" ");
            string firstNameStudent = splitStudentNames[0];
            string lastNameStudent = splitStudentNames[1];

            IStudent student = students.FindByName(studentName);
            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstNameStudent, lastNameStudent);
            }
            
            IUniversity university = universities.FindByName(universityName);
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach (var examId in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(examId))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstNameStudent, lastNameStudent, universityName);
            }
            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstNameStudent, lastNameStudent, universityName);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {students.Models.Where(s => s.University == university).Count()}");
            sb.AppendLine($"University vacancy: {university.Capacity - students.Models.Where(s => s.University == university).Count()}");
            return sb.ToString().TrimEnd();
        }
    }
}
