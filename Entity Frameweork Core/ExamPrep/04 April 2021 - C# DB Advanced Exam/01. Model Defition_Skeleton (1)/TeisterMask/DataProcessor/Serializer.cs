namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToArray()
                .Where(x => x.Tasks.Any())
                .Select(x => new XmlExportProjectWithTheirTasksDto
                {
                    ProjectName = x.Name,
                    TaskCount = x.Tasks.Count(),
                    HasEndDate = x.DueDate != null ? "Yes" : "No",
                    Tasks = x.Tasks.Select(x=>new XmlExportTaskDto
                    {
                        Name = x.Name,
                        Lable = x.LabelType.ToString()
                    })
                    .OrderBy(x=>x.Name)
                    .ToArray()
                })
                .OrderByDescending(x=>x.TaskCount)
                .ThenBy(x=>x.ProjectName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(XmlExportProjectWithTheirTasksDto[]), new XmlRootAttribute("Projects"));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using var writer = new StringWriter();
            serializer.Serialize(writer, projects ,ns);

            return writer.ToString();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(x => x.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks.Where(x => x.Task.OpenDate >= date)
                    .OrderByDescending(x => x.Task.DueDate)
                    .ThenBy(x => x.Task.Name)
                    .Select(x => new
                    {
                        TaskName = x.Task.Name,
                        OpenDate = x.Task.OpenDate.ToString("d",CultureInfo.InvariantCulture),
                        DueDate = x.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = x.Task.LabelType.ToString(),
                        ExecutionType = x.Task.ExecutionType.ToString(),
                    })
                    .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}