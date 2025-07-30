using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormSubmit.Custom_Validation
{
    public class Stringlength: ValidationAttribute
    {
        private readonly int _maxvalue ;
        private readonly int _minvalue ;

        public Stringlength(int minvalue = 5,int maxvalue=20)
        {
            _minvalue = minvalue;
            _maxvalue = maxvalue;
        }

        public override bool IsValid(object value)
        {
            if(value is string Username)
            {
                int strlength = Username.Length;
                if (strlength > _maxvalue || strlength < _minvalue) 
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public override string FormatErrorMessage(string Username)
        {
            return $"{Username} must have 5 to 20 charecters!";
        }

    }

}