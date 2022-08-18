namespace TeisterMask.DataProcessor
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
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(XmlImportProjectDto[]), new XmlRootAttribute("Projects"));
            using var reader = new StringReader(xmlString);
            var dtoProjects = (XmlImportProjectDto[])serializer.Deserialize(reader);
            foreach (var dto in dtoProjects)
            {
                var isValidProjectOpenDate = DateTime
                    .TryParseExact(dto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var parsedProjectOpenDate);

                var isValidProjectDueDate = DateTime
                    .TryParseExact(dto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var parsedProjectDueDate);

                if (!IsValid(dto) || !isValidProjectOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var tasks = new List<Task>();
                foreach (var task in dto.Tasks)
                {
                    var isValidTaskOpenDate = DateTime
                        .TryParseExact(task.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture ,
                        DateTimeStyles.None,
                        out var parsedTaskOpenDate);
                    var isValidTaskDueDate = DateTime
                        .TryParseExact(task.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, 
                        out var parsedTaskDueDate);

                    if (!IsValid(task) || !isValidTaskOpenDate || !isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (parsedTaskOpenDate < parsedProjectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (isValidProjectDueDate)
                    {
                        if(parsedTaskDueDate > parsedProjectDueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    Task currTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = parsedTaskOpenDate,
                        DueDate = parsedTaskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType,
                    };
                    tasks.Add(currTask);
                }
                Project project = new Project
                {
                    Name = dto.Name,
                    OpenDate = parsedProjectOpenDate,
                    DueDate = isValidProjectDueDate ?(DateTime?) parsedProjectDueDate : null,
                    Tasks = tasks,
                };
                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedProject, dto.Name , tasks.Count()));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employeeDto = JsonConvert.DeserializeObject<JsonImportEmployeesDto[]>(jsonString);

            foreach (var empl in employeeDto)
            {
                if (!IsValid(empl))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var emloyee = new Employee
                {
                    Username = empl.Username,
                    Email = empl.Email,
                    Phone = empl.Phone,
                };

                var listEmplTasks = new List<EmployeeTask>();


                foreach (var taskId in empl.Tasks)
                {
                    var task = context.Tasks.Find(taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var emplTask = new EmployeeTask
                    {
                        Employee = emloyee,
                        Task = task
                    };

                    listEmplTasks.Add(emplTask);
                }

                emloyee.EmployeesTasks = listEmplTasks;

                context.Employees.Add(emloyee);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee,empl.Username,listEmplTasks.Count()));
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