namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context.Producers
                .FirstOrDefault(x => x.Id == producerId).Albums
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleseDate = x.ReleaseDate,//"MM/dd/yyyy"
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.Writer)
                    .Select(x => new
                    {
                        SongName = x.Name,
                        SongPrie = x.Price,//:f2
                        WriterName = x.Writer.Name,
                    }),
                    AlbumPrice = x.Price//:f2
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();


            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                int counter = 0;
                foreach (var song in album.Songs)
                {
                    
                    counter++;
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrie:f2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //Export the songs which are above the given duration.
        //For each Song, export its Name, Performer Full Name, Writer Name, Album Producer and Duration (in format("c")).
        //Sort the Songs by their Name (ascending), by Writer (ascending) and by Performer (ascending).

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context.Songs
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(a => a.Album)
                .ThenInclude(a => a.Producer)
                .ToArray()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    x.Name,
                    SongPerformer = x.SongPerformers.Select(x => x.Performer.FirstName + " " + x.Performer.LastName).FirstOrDefault(),
                    SongWriter = x.Writer.Name,
                    SongAlbumProdcer = x.Album.Producer.Name,
                    SongDuration = x.Duration.ToString("c")
                }).OrderBy(x => x.Name).ThenBy(x => x.SongWriter).ThenBy(x => x.SongPerformer).ToArray();

            int counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.SongWriter}");
                sb.AppendLine($"---Performer {song.SongPerformer}");
                sb.AppendLine($"---AlbumProducer: {song.SongAlbumProdcer}");
                sb.AppendLine($"---Duration: {song.SongDuration}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
