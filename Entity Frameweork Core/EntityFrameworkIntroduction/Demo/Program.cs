using Demo.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();
            //Console.WriteLine(db.Songs.Count());
            //var artists = db.Artists.OrderByDescending(x => x.SongArtists.Count())
            //    .Select(x=>new {x.Name, Count = x.SongArtists.Count()}).Take(10).ToList();

            //foreach (var item in artists)
            //{
            //    Console.WriteLine($"{item.Name} {item.Count}");
            //}

            //var songs = db.Songs.Where(x => x.SongArtists.Any(a => a.Artist.Name == "Eminem"));
            //foreach (var item in songs)
            //{
            //    Console.WriteLine(item.Name );
            //}

            //var songs = db.Songs
            //    .Where(x => x.SongArtists.Count() > 3)
            //    .Select(x => new
            //    {
            //        x.Name,
            //        Artist = string.Join(", ", x.SongArtists
            //            .Select(a => a.Artist.Name))
            //    }).ToList();

            //foreach (var item in songs)
            //{
            //    Console.WriteLine(item.Artist + " - " + item.Name);
            //}

            //Console.OutputEncoding = System.Text.Encoding.Unicode;

            //var songs = db.Songs.Select(x => new
            //{
            //    x.Name,
            //    ArtistsCount = x.SongArtists.Count(),
            //    FirstArtist = x.SongArtists.FirstOrDefault().Artist.Name,
            //    SourceName = x.Source.Name,
            //    AnyASArtist = x.SongArtists.Any(x=>x.Artist.Name.StartsWith("С"))
            //}).OrderByDescending(x=>x.FirstArtist).Take(10);

            //Console.WriteLine(songs.ToQueryString());

            //List<List<string>> list = new List<List<string>>
            //{
            //    new List<string> { "Victor", "Niki" ,"Stamo" },
            //    new List<string> { "Stoyan", "Joro" ,"Doncho" },
            //    new List<string> { "Plamen", "Mariq" ,"Ivo" },
            //};

            //List<string> selectManyResult = list.SelectMany(x => x).ToList();


            ///CRUD///

            //var artist = new Artist
            //{
            //    CreatedOn = DateTime.UtcNow,
            //    Name = "Nakov",
            //    MoneyEarned = 100.12m,
            //};
            //artist.SongArtists.Add(new SongArtist
            //{
            //    Song = new Song
            //    {
            //        Name = "SoftUni",
            //        CreatedOn = DateTime.UtcNow,
            //    },

            //});
            //artist.SongArtists.Add(new SongArtist
            //{
            //    Song = new Song
            //    {
            //        Name = "Rakiq",
            //        CreatedOn = DateTime.UtcNow,
            //    }
            //});

            //db.Artists.Add(artist);
            //db.SaveChanges();

            //var song = new Song
            //{
            //    Name = "YouTube Song",
            //    Source = new Source
            //    {
            //        Name = "SorceTest"
            //    }
            //};
            //db.Songs.Add(song);
            //db.SaveChanges();

            //var song = db.Songs.OrderByDescending(x => x.Id).FirstOrDefault();
            //song.CreatedOn = DateTime.UtcNow;
            //db.SaveChanges();

            var song = db.Songs.OrderByDescending(x => x.Id).FirstOrDefault();
            db.Songs.Remove(song);
            db.SaveChanges();

        }
    }
}
