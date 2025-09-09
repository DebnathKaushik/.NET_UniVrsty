using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repos
{
    internal class NewsRepo : INewsRepo
    {
        NewsContext db;
        //Database Initialize
        public NewsRepo()
        {
            db = new NewsContext();
        }

        public List<News> Get()
        {
            var news = db.Newses.ToList();
            return news;
        }

        public News Get(int Id)
        {
            var news = db.Newses.Find(Id);
            return news;
        }

        public News Get(DateTime date)
        {
            return db.Newses.FirstOrDefault(n => n.Date.Date == date.Date);
        }


        public News Get(DateTime Date, Catagory CName)
        {
            return db.Newses
              .FirstOrDefault(n => n.Date.Date == Date.Date && n.CId == CName.Id);
        }

        public News Get(Catagory CName)
        {
            return db.Newses
                .Where(n => n.CId == CName.Id)
                .OrderByDescending(n => n.Date)
                .FirstOrDefault();
        }
    }
}
