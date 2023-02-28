using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem_.Data.Common
{
    public static class ValidationConstants
    {
        //Student
        public const int StudentNameMaxLength = 100;
        public const int StudentPhoneNumberLength = 10;

        //Couse 
        public const int CoueseNameMaxLength = 80;

        //Resource
        public const int ResourceNameMaxLength = 50;
        public const int CourseUrlMaxLength = 2048;

        //Homework
        public const int HomeworkContentMaxLength = 2048;
    }
}
