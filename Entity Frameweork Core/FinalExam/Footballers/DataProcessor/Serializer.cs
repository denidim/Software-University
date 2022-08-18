namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches.ToArray()
                .Where(x => x.Footballers.Any())
                .Select(x => new ExportXmlDto
                {
                    FootballersCount = x.Footballers.Count(),
                    CoachName = x.Name,
                    Footballers = x.Footballers.Select(x => new ExportFootballerXmlDto
                    {
                        Name = x.Name,
                        Position = x.PositionType.ToString()
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x=> x.Footballers.Count())
                .ThenBy(x=> x.CoachName)
                .ToArray();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportXmlDto[]),
                    new XmlRootAttribute("Coaches"));
            var sw = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, coaches, ns);
            return sw.ToString();

        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams.ToArray()
                .Where(x => x.TeamsFootballers.Any(X => X.Footballer.ContractStartDate >= date))
                .Select(X => new
                {
                    Name = X.Name,
                    Footballers = X.TeamsFootballers
                    .Where(x=>x.Footballer.ContractStartDate >= date )
                    .OrderByDescending(x=>x.Footballer.ContractEndDate)
                    .ThenBy(x=>x.Footballer.Name)
                    .Select(x => new
                    {
                        FootballerName = x.Footballer.Name,
                        ContractStartDate = x.Footballer.ContractStartDate.ToString("d",CultureInfo.InvariantCulture),
                        ContractEndDate = x.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = x.Footballer.BestSkillType.ToString(),
                        PositionType = x.Footballer.PositionType.ToString()
                    }).ToArray()
                })
                .OrderByDescending(x=>x.Footballers.Count())
                .ThenBy(x=>x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
