namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(XmlPlayImportDto[]), new XmlRootAttribute("Plays"));

            using var reader = new StringReader(xmlString);

            XmlPlayImportDto[] playsDto = (XmlPlayImportDto[])serializer.Deserialize(reader);

            foreach (var play in playsDto)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan timeSpan = TimeSpan.ParseExact(play.Duration, "c", CultureInfo.InvariantCulture);
                if (timeSpan.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currPlay = new Play
                {
                    Title = play.Title,
                    Duration = timeSpan,
                    Rating = play.Rating,
                    Genre = Enum.Parse<Genre>(play.Genre),
                    Description = play.Description,
                    Screenwriter = play.Screenwriter,
                };

                context.Plays.Add(currPlay);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(),play.Rating ));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportXmlActorsDto[]), new XmlRootAttribute("Casts"));

            using var reader = new StringReader(xmlString);

            ImportXmlActorsDto[] castDto = (ImportXmlActorsDto[])serializer.Deserialize(reader);

            foreach (var actor in castDto)
            {
                if (!IsValid(actor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var currActor = new Cast
                {
                    FullName = actor.FullName,
                    IsMainCharacter = actor.IsMainCharacter,
                    PhoneNumber = actor.PhoneNumber,
                    PlayId = actor.PlayId
                };

                context.Casts.Add(currActor);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportActor,actor.FullName,actor.IsMainCharacter == false ? "lesser" : "main"));
            }
            return sb.ToString().TrimEnd();

        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var theatreDto = JsonConvert.DeserializeObject<ImportJsonTheatreDto[]>(jsonString);


            foreach (var dto in theatreDto)
            {
                if(!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theathe = new Theatre
                {
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls,
                    Director = dto.Director,
                };

                var tickets = new List<Ticket>();

                foreach (var item in dto.Tickets)
                {
                    if (!IsValid(item))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        Price = item.Price,
                        RowNumber = item.RowNumber,
                        PlayId = item.PlayId
                    };

                    tickets.Add(ticket);
                }

                theathe.Tickets = tickets;
                context.Theatres.Add(theathe);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportTheatre, dto.Name, tickets.Count()));
            }

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
