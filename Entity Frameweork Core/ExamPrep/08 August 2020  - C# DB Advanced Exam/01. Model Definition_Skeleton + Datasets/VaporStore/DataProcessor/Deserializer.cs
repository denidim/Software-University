namespace VaporStore.DataProcessor
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
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			//deserialize from json ->into-> dto
			var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

			
			foreach (var dto in gamesDto)
            {
				//validate attributes and manual
				if ((!IsValid(dto)) || dto.Tags.Count() < 1)
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				//import from dto ->into-> dbModel
				var genre = context.Genres.FirstOrDefault(x=>x.Name == dto.Genre)
					?? new Genre { Name = dto.Genre };

				var developer = context.Developers.FirstOrDefault(x => x.Name == dto.Developer)
					?? new Developer { Name = dto.Developer };

				var game = new Game
				{
					Name = dto.Name,
					Price = dto.Price,
					ReleaseDate = dto.ReleaseDate.Value,
					Genre = genre,
					Developer = developer,
				};

                foreach (var jsonTagName in dto.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTagName)
						?? new Tag { Name = jsonTagName };

					game.GameTags.Add(new GameTag { Tag = tag });
                }

				//import from dbModel ->into-> database table
				context.Games.Add(game);
				context.SaveChanges();
				sb.AppendLine($"Added {dto.Name} ({dto.Genre}) with {dto.Tags.Count()} tags");
			}
			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			//deserialize from json ->into-> dto
			var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

			foreach (var dto in usersDto)
			{
				//validate attributes and manual
				if (!IsValid(dto) || !dto.Cards.All(IsValid))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				//import from dto ->into-> dbModel
				var user = new User
				{
					FullName = dto.FullName,
					Username = dto.Username,
					Email = dto.Email,
					Age = dto.Age,
					Cards = dto.Cards.Select(x => new Card
					{
						Number = x.Number,
						Cvc = x.CVC,
						Type = x.Type.Value
					}).ToArray(),
				};

				//import from dbModel ->into-> database table
				context.Users.Add(user);
				context.SaveChanges();
				sb.AppendLine($"Imported {dto.Username} with {dto.Cards.Count()} cards");
			}
			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();

			//deserialize from xml ->into-> dto

			var reader = new StringReader(xmlString);

			var serializer = new XmlSerializer(typeof(ImportPurchaseXmlDto[]), new XmlRootAttribute("Purchases"));

			ImportPurchaseXmlDto[] purchaseDtos = (ImportPurchaseXmlDto[])serializer.Deserialize(reader);


			foreach (var dto in purchaseDtos)
			{
				//validate attributes and manual
				if (!IsValid(dto))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				//import from dto ->into-> dbModel

				var card = context.Cards.FirstOrDefault(x => x.Number == dto.CardNumber);
				var game = context.Games.FirstOrDefault(x => x.Name == dto.GameName);
				var userName = card.User.Username;

				Purchase purchase = new Purchase
				{
					Type = dto.Type.Value,
					ProductKey = dto.ProductKey,
					Card = card,
					Date = DateTime.ParseExact(dto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Game = game,
				};

				//import from dbModel ->into-> database table
				context.Purchases.Add(purchase);
				context.SaveChanges();
				sb.AppendLine($"Imported {dto.GameName} for {userName}");
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