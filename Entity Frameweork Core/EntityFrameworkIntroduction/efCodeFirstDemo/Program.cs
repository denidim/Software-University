using efCodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace efCodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.Migrate();
        }

    }
}
