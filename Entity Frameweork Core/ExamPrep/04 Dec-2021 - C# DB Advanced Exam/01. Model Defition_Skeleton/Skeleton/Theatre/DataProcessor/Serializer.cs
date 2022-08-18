namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .OrderByDescending(x => x.NumberOfHalls)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = x.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .OrderByDescending(x => x.Price)
                    .Select(x => new
                    {
                        Price = Math.Round(x.Price, 2),
                        RowNumber = x.RowNumber
                    }).ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(theaters,Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays.ToArray()
                .Where(x => x.Rating <= rating)
                .OrderBy(x=>x.Title)
                .ThenByDescending(x=>x.Genre)
                .Select(x => new ExportXmlPlaysDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                    .Where(x=>x.IsMainCharacter)
                    .OrderByDescending(x => x.FullName)
                    .Select(x=> new ExportXmlActorsDto
                    {
                        FullName = x.FullName,
                        MainCharacter = $"Plays main character in '{x.Play.Title}'.",
                    }).ToArray()

                }).ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportXmlPlaysDto[]),new XmlRootAttribute("Plays"));
            var sw = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, plays, ns);
            return sw.ToString();
        }
    }
}
