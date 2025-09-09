using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CatNewsDTO:CatagoryDTO
    {
        public List<NewsDTO> News { get; set; }
    }
}
