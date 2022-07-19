using SoftUni.Data;
using System;
using System.Linq;
using System.Text;
using SoftUni.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = GetEmployeesByFirstNameStartingWithSa(context);

            Console.WriteLine(result);

        }

        public static string RemoveTown(SoftUniContext context)
        {
            const string townName = "Seattle";

            var town = context.Towns.FirstOrDefault(x => x.Name == townName);

            var addresses = context.Addresses.Where(x => x.Town.Name == townName).ToList();

            context.Employees.Where(x => x.Address.Town.Name == townName).ToList().ForEach(e => e.AddressId = null);

            context.RemoveRange(addresses);

            context.Towns.Remove(town);

            context.SaveChanges();

            var sb = new StringBuilder();

            sb.AppendLine($"{addresses.Count} addresses in {townName} were deleted");

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectForDeletion = context.Projects.OrderByDescending(x => x.ProjectId == 2).FirstOrDefault();

            var employeeProjReff = context.EmployeesProjects.Where(x => x.ProjectId == projectForDeletion.ProjectId).ToList();

            context.EmployeesProjects.RemoveRange(employeeProjReff);

            context.Projects.Remove(projectForDeletion);

            context.SaveChanges();

            var sb = new StringBuilder();

            context.Projects.Take(10).Select(x=>new {x.Name }).ToList().ForEach(p=>sb.AppendLine(p.Name));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);
            
            var sb = new StringBuilder();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var empl in employees)
            {
                empl.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} (${empl.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects.OrderByDescending(x => x.StartDate).Take(10).Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate,
                })
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var proj in latestProjects)
            {
                sb.AppendLine(proj.Name);
                sb.AppendLine(proj.Description);
                sb.AppendLine(proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Select(x => new
                {
                    name = x.Name,
                    managerFirstName = x.Manager.FirstName,
                    managerLastName = x.Manager.LastName,
                    employees = x.Employees.OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName).Select(x => new
                    {
                        employeeFirstName = x.FirstName,
                        employeeLastName = x.LastName,
                        employeeJobTitle = x.JobTitle
                    })
                }).Where(x => x.employees.Count() > 5)
                .OrderBy(x => x.employees.Count())
                .ThenBy(x => x.name)
                .ToList();


            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.name} - {department.managerFirstName} {department.managerLastName}");

                foreach (var empl in department.employees)
                {
                    sb.AppendLine($"{empl.employeeFirstName} {empl.employeeLastName} - {empl.employeeJobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees.Select(x => new
            {
                x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.JobTitle,
                project = x.EmployeesProjects.OrderBy(x => x.Project.Name).Select(x => new
                {
                    x.Project.Name
                })
            }).FirstOrDefault(x => x.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var item in employee147.project)
            {
                sb.AppendLine($"{item.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var address = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    x.Town.Name,
                    x.Employees.Count
                })
                .OrderByDescending(x=>x.Count)
                .ThenBy(x=>x.Name)
                .ThenBy(x=>x.AddressText)
                .Take(10)
                .ToList();
            var sb = new StringBuilder();
            foreach (var item in address)
            {
                sb.AppendLine($"{item.AddressText}, {item.Name} - {item.Count} employees");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x=>x.EmployeesProjects)
                .ThenInclude(x=>x.Project)
                .Where(x=>x.EmployeesProjects
                .Any(p=>p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    eFirstName = x.FirstName,
                    eLastName = x.LastName,
                    mFirstName = x.Manager.FirstName,
                    mLastName = x.Manager.LastName,
                    projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.eFirstName} {emp.eLastName} - Manager: {emp.mFirstName} {emp.mLastName}");

                foreach (var project in emp.projects)
                {
                    var endDate = project.EndDate.HasValue 
                        ? project.EndDate.Value
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) 
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            nakov.Address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.SaveChanges();

            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.Address.AddressId
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            foreach (var item in employees)
            {
                sb.AppendLine(item.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                   departmentName = x.Department.Name,
                    x.Salary,
                }).Where(x => x.departmentName == "Research and Development")
                .OrderBy(x => x.Salary).ThenByDescending(x=>x.FirstName).ToArray();

            var sb = new StringBuilder();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} from {item.departmentName} - ${item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary,
                })
                .Where(x=>x.Salary>50000)
                .OrderBy(x => x.FirstName).ToArray();

            var sb = new StringBuilder();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} - {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                x.EmployeeId,
                x.FirstName,
                x.MiddleName,
                x.LastName,
                x.JobTitle,
                x.Salary,
            }).OrderBy(x=>x.EmployeeId).ToArray();

            var sb = new StringBuilder();

            foreach (var item in employees)
            {
               sb.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.JobTitle} {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
