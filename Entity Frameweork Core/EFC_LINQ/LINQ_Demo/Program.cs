using LINQ_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Z.EntityFramework.Plus;

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

            db.Songs.Where(x => x.Id == 1).Update(oldSong => new Song
            {
                ModifiedOn = DateTime.Now
            }) ;

            var songs = db.Songs;
            foreach (var item in songs)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Source.Name); 
            }

        }
    }
}
