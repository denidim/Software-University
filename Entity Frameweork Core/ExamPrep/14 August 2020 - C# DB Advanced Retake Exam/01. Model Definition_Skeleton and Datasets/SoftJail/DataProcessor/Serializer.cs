namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .OrderBy(x=>x.FullName)
                .ThenBy(x => x.Id)
                .Where(x => ids.Contains(x.Id)).ToList()
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.OrderBy(x=>x.Officer.FullName)
                    .Select(x => new
                    {
                        OfficerName = x.Officer.FullName,
                        Department = x.Officer.Department.Name
                    }).ToList(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(x => x.Officer.Salary)
                });

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = prisonersNames.Split(",",StringSplitOptions.RemoveEmptyEntries);

            var data = context.Prisoners.Where(x => prisoners.Contains(x.FullName))
                .OrderBy(x => x.FullName)
                .ThenBy(x => x.Id)
                .Select(x => new ExportXmlDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(x => new ExportMsgDto
                    {
                        Description = string.Join("", x.Description.Reverse())
                    }).ToArray()
                })
                .ToArray();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportXmlDto[]),
                    new XmlRootAttribute("Prisoners"));
            var sw = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, data, ns);
            return sw.ToString();
        }
    }
}