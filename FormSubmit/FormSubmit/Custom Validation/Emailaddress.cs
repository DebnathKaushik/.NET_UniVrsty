using FormSubmit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace FormSubmit.Custom_Validation
{
    public class Emailaddress:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationcontext)
        {
            var model = validationcontext.ObjectInstance as Student;
            
            string email = model.Email;
            string email_id_Parts = email.Split('@')[0];  // extract (id) from whole email
            string id = model.Id;

            string expectedEmail = id + "@aiub.edu";
            if (!email.Equals(expectedEmail, StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult ($"Email must be this format: {id}@aiub.edu / not " +
                    $"{email_id_Parts} (id)");
            }

            return ValidationResult.Success;    
        }

    }
}