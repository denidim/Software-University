namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var departmentDto = JsonConvert.DeserializeObject<ImportDepartmentsAndCellsDto[]>(jsonString);

            foreach (var dto in departmentDto)
            {
                if (!IsValid(dto) || !dto.Cells.All(IsValid) || dto.Cells.Count() < 1)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var cells = new List<Cell>();

                foreach (var item in dto.Cells)
                {
                    Cell cell = new Cell
                    {
                        CellNumber = item.CellNumber,
                        HasWindow = item.HasWindow,
                    };
                    cells.Add(cell);
                }

                var departnemt = new Department
                {
                    Name = dto.Name,
                    Cells = cells
                };
                context.Departments.Add(departnemt);
                context.SaveChanges();
                sb.AppendLine($"Imported {dto.Name} with {cells.Count()} cells");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var prisonerDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            foreach (var dto in prisonerDto)
            {
                if(!IsValid(dto) || !dto.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleseDate = DateTime
                    .TryParseExact(dto.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var releseDate);

                var prisoner = new Prisoner
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = DateTime.ParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = isValidReleseDate ? (DateTime?)releseDate : null,
                    Bail = dto.Bail,
                    CellId = dto.CellId,
                    Mails = dto.Mails.Select(x=>new Mail
                    {
                        Description = x.Description,
                        Sender=x.Sender,
                        Address=x.Address,
                    }).ToArray()
                };
                context.Prisoners.Add(prisoner);
                context.SaveChanges();
                sb.AppendLine($"Imported {dto.FullName} {dto.Age} years old");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializaer = new XmlSerializer(typeof(ImportOfficersXmlDto[]), new XmlRootAttribute("Officers"));

            var reader = new StringReader(xmlString);

            var officersDto = (ImportOfficersXmlDto[])serializaer.Deserialize(reader);

            foreach (var dto in officersDto)
            {
                if(!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = dto.Name,
                    Salary = dto.Salary,
                    Position = Enum.Parse<Position>(dto.Position),
                    Weapon = Enum.Parse<Weapon>(dto.Weapon),
                    DepartmentId = dto.DepartmentId,
                    OfficerPrisoners = dto.Prisoners.Select(x=>new OfficerPrisoner
                    {
                        PrisonerId = x.Id,
                    })
                    .ToArray()
                };
                context.Officers.Add(officer);
                context.SaveChanges();
                sb.AppendLine($"Imported {dto.Name} ({dto.Prisoners.Count()} prisoners)");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}