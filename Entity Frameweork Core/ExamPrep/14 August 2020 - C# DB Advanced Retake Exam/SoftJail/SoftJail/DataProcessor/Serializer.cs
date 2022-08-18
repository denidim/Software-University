namespace SoftJail.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var result = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CelLNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(x => x.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = x.PrisonerOfficers
                        .Sum(x => x.Officer.Salary)
                        .ToString("F2")
                })
                .OrderBy(x => x.TotalOfficerSalary)
                .ThenBy(x => x.Id)
                .ToList();

            string json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var result = context.Prisoners
                .Include(x => x.Mails)
                .Where(x => names.Contains(x.FullName))
                .ProjectTo<PrisonerViewModel>()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var xml = XmlConverter.Serialize(result, "Prisoners");

            return xml;
        }
    }
}