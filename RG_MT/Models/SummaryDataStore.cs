using RG_MT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG_MT.Models
{
    public class SummaryDataStore
    {
        public List<Summary> Summaries { get; set; }
        private readonly SRMSContext _context;

        public SummaryDataStore(SRMSContext context)
        {
            _context = context;
            List<Course> courses = _context.Courses.ToList();
            List<Student> students = _context.Students.ToList();
            int courseCount = 0;
            int studentCount = 0;
            foreach (Course course in courses)
            {
                courseCount++;
            }
            foreach (Student s in students)
            {
                studentCount++;
            }
            Summaries = new List<Summary>()
            {
                new Summary(){Students=studentCount, Courses=courseCount}
            };
        }
    }
}
