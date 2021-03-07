using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RG_MT.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display (Name ="Student First Name")]
        [Required(ErrorMessage ="{0} is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Student Last Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(15,MinimumLength=3, ErrorMessage ="{0} must be {2} to {1} character long")]
        public string LastName { get; set; }

        [Display(Name = "Student Birth Date")]
        [Range(typeof(DateTime), "01/01/1981", "12/31/2000",ErrorMessage = "Value for {0} must be between {1:d} and {2:d}")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 
    }
}
