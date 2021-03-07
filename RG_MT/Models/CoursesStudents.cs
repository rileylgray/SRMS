using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RG_MT.Models
{
    public class CoursesStudents
    {
        public Course course { get; set; }
        public List<EnrolledStudent> EnrolledStudents { get; set; }

        public CoursesStudents()
        {
            EnrolledStudents = new List<EnrolledStudent>();
        }
    }
    public class EnrolledStudent
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime birthDay { get; set; }
        public bool isEnrolled { get; set; }

    }
}