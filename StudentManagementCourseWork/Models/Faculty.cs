using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementCourseWork.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }


        public virtual List<Student> Students {get; set;}
    }
}