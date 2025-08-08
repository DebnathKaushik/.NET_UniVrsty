using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Dept_EF.DTOs
{
    public class studentDTO
    {
        [Required]
        public string Student_Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Dept_Name { get; set; }
        [Required]
        public int Foreign_Dept_Id { get; set;}
    }
}