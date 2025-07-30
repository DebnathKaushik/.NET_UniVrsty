using FormSubmit.Custom_Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormSubmit.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s\.-]+$", ErrorMessage ="Name should be only Letter!")]
        public string Name { get; set; }

        [Required]
        [Stringlength]   // Custom validator
        [RegularExpression(@"^\S*$",ErrorMessage ="Username have no spaces")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Id should be 09-00009-3")]
        public string Id { get; set; }

        [Required]
        [MinAge(18)]    // Custom Validator 
        public DateTime? DOB { get; set; }
        
        [Required]
        [Emailaddress]    // Custom Validator 
        public string Email { get; set; }

        
    }

}
