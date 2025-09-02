using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDeptApi.DTOs
{
    public class StudentDTO
    {
        public int S_id { get; set; }
        public string S_name { get; set; }
        public string S_cgpa { get; set; }
        public int Dept_id { get; set; }
    }
}