using FormSubmit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormSubmit.Custom_Validation
{
    public class MinAge:ValidationAttribute
    {
        private readonly int _minAge;

        public MinAge(int minAge=18)
        {
            _minAge = minAge;
        }
        public override bool IsValid(object value)
        {
            if(value is DateTime DOB)
            {
                var today = DateTime.Today;
                int age = today.Year - DOB .Year;
                return age >= _minAge;
            }
            return false;
            
        }
        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be {_minAge} years old.";
        }
    }
}