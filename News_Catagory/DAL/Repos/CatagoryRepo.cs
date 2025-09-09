using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CatagoryRepo : ICatagoryRepo
    {
        NewsContext db;
        //Database Initialize
        public CatagoryRepo()
        {
            db = new NewsContext();
        }


        public bool Delete(int Id)
        {
            var st = db.Catagories.Find(Id);
            db.Catagories.Remove(st);
            db.SaveChanges();
            return true;
        }


        public bool Update(Catagory c)
        {
            var exist_std = db.Catagories.Find(c.Id);
            db.Entry(exist_std).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        public Catagory GetByName(string name)
        {
            return db.Catagories.FirstOrDefault(c => c.CName == name);

        }

    }
}
