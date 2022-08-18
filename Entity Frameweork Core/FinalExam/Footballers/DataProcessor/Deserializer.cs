namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
			var sb = new StringBuilder();

			var reader = new StringReader(xmlString);

			var serializer = new XmlSerializer(typeof(ImportCoachesDto[]), new XmlRootAttribute("Coaches"));

			ImportCoachesDto[] coachesDto = (ImportCoachesDto[])serializer.Deserialize(reader);


			foreach (var dto in coachesDto)
			{
				//validate attributes and manual
				if (!IsValid(dto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

                var coach = new Coach
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                };

                foreach (var footbaler in dto.Footballers)
                {
                    var isValidStartDate = DateTime
                  .TryParseExact(footbaler.ContractStartDate, "dd/MM/yyyy",
                  CultureInfo.InvariantCulture,
                  DateTimeStyles.None,
                  out var parsedValidStartDate);

                    var isValidEndDate = DateTime
                 .TryParseExact(footbaler.ContractEndDate, "dd/MM/yyyy",
                 CultureInfo.InvariantCulture,
                 DateTimeStyles.None,
                 out var parsedValidEndDate);

                    if (!IsValid(footbaler) || !isValidEndDate || !isValidStartDate || parsedValidStartDate > parsedValidEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;

                    }

                    var footboller = new Footballer
                    {
                        Name = footbaler.Name,
                        ContractStartDate = parsedValidStartDate,
                        ContractEndDate = parsedValidEndDate,
                        BestSkillType = (BestSkillType)footbaler.BestSkillType,
                        PositionType = (PositionType)footbaler.PositionType,
                    };

                    coach.Footballers.Add(footboller);
                    
                }
                context.Coaches.Add(coach);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, dto.Name, coach.Footballers.Count()));


			}
			return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var teamDto = JsonConvert.DeserializeObject<ImportTeamsJsonDto[]>(jsonString);

            foreach (var dto in teamDto)
            {
                if ((!IsValid(dto)) || dto.Trophies < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Trophies = dto.Trophies,
                };

                var listFootbolers = new List<TeamFootballer>();

                foreach (var footboller in dto.Footballers.Distinct())
                {
                    var curr = context.Footballers.Find(footboller);

                    if(curr == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var teamFootboler = new TeamFootballer
                    {
                        Team = team,
                        Footballer = curr
                    };

                    listFootbolers.Add(teamFootboler);
                }

                team.TeamsFootballers = listFootbolers;

                context.Teams.Add(team);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedTeam ,team.Name, listFootbolers.Count()));

            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
