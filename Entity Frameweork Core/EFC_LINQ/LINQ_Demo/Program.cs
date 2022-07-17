using LINQ_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LINQ_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();

            db.Songs
                .Where(x => x.Source.Name == "User")
                .Select(x => new {x.Name,Source = x.Source.Name})
                .ToList()
                .ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
