using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INewsRepo
    {

        List<News> Get();

        News Get(int Id);

        News Get(DateTime Date);

        News Get(DateTime Date, Catagory CName);

        List<News> Get(Catagory Cname);

        

    }
}
