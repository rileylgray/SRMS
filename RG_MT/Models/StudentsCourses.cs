using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG_MT.Models
{
    public class StudentsCourses
    {
        public Student student { get; set; }
        public List<EnrolledClass> EnrolledClasses { get; set; }

        public StudentsCourses()
        {
            EnrolledClasses = new List<EnrolledClass>();
        }
    }
    public class EnrolledClass
    {
        public int Id { get; set; }
        public int courseCode { get; set; }
        public string courseName { get; set; }
        public int CourseCredits { get; set; }
        public bool isEnrolled { get; set; }
    }
}
