using codeFirstDemo.Models;
using System.Linq;
using System.Collections.Generic;

namespace codeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // dotnet ef database update

            var db = new ApplcationDbContext();
            db.Database.EnsureCreated();
            //db.categories.add(new category
            //{
            //    title = "sport",
            //    news = new list<news>
            //    {
            //        new news
            //        {
            //            title = "some title demo",
            //            content = "some content",
            //            comments = new list<comment>
            //            {
            //                new comment {author = "niki", content = "da"},
            //                new comment {author = "stoyn", content = "ne"},
            //            }

            //        }
            //    }

            //});
            //db.savechanges();
            //db.categories.add(new category
            //{
            //    title = "fishing"
            //});

            //db.savechanges();

            var titles = db.Categories.Where(x => x.Title == "sport")
                .Select(x=> new {categoryID = x.Id,x.Title});

            foreach (var item in titles)
            {
                System.Console.WriteLine($"{item.categoryID} {item.Title}");
            }
        }
    }
}
