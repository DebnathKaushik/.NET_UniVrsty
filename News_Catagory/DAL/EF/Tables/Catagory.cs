using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Catagory
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        public string CName { get; set; }
    }
}
