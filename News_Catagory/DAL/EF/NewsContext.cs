using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class NewsContext: DbContext
    {
        public DbSet<News> Newses { get; set; }
        public DbSet<Catagory> Catagories  { get; set; }
    }
}
