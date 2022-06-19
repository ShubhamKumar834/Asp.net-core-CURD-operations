using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShubhamDhimanWebApp1.Models
{
    public class StudentData
    {
        public int ID { get; set; }
        [Required]
        public int RollNumber { get; set; }
        [Required(ErrorMessage ="Please enter student name.")]
        public string Student_Name{get;set;}
        [Required]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage ="Please enter course.")]
        public string Course { get; set; }
        [Required]
        public decimal Fees { get; set; }
    }
}
