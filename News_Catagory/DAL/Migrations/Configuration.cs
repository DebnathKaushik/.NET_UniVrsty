namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.NewsContext context)
        {
           
                /*
                    var categories = new List<Catagory>
                    {
                        new Catagory { Id = 1, CName = "Global" },
                        new Catagory { Id = 2, CName = "Health" },
                        new Catagory { Id = 3, CName = "Education" }
                    };

                    categories.ForEach(c => context.Catagories.AddOrUpdate(cat => cat.Id, c));

                    // Seed Items
                    var items = new List<News>
                    {
                        new News { Id = 1, Title = "AI Revolution", Date = DateTime.Now, CId = 1 },
                        new News { Id = 2, Title = "Mental Wellness", Date = DateTime.Now, CId = 2 },
                        new News { Id = 3, Title = "Online Learning", Date = DateTime.Now, CId = 3 }
                    };

                    items.ForEach(i => context.Newses.AddOrUpdate(it => it.Id, i));

                    context.SaveChanges(); */



        }
    }
}
