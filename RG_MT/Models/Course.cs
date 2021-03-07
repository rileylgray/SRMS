using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RG_MT.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "{0} is Required")]
        [Range(10000, 99999, ErrorMessage = "{0} must be between {1} and {2}")]
        public int CourseNumber { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "{0} is Required")]
        public string CourseTitle { get; set; }

        [Display(Name = "Course Credits")]
        [Required(ErrorMessage = "{0} is Required")]
        [Range(3,6, ErrorMessage ="{0} must be between {1} and {2}")]
        public int Credits { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
