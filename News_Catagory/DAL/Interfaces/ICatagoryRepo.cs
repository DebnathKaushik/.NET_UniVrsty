using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICatagoryRepo
    {
        bool Update(Catagory c);
        bool Delete(int Id);

        Catagory GetByName(string name);
    }
}
