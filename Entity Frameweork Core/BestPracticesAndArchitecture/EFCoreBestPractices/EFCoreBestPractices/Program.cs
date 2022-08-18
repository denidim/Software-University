using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EFCoreBestPractices.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EFCoreBestPractices.Infrastructure.Data.Common;
using EFCoreBestPractices.Core.Contracts;
using EFCoreBestPractices.Core.Services;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //.AddUserSecrets("5d525de6-1afd-46d9-a3a2-ff6acd0db765")
    .Build();

var serviceProvider = new ServiceCollection()
    .AddDbContext<SoftUniContext>(options => 
    {
        options.UseSqlServer(configuration.GetConnectionString("SoftUniConnection"));
    })
    .AddScoped<ISoftUniRepository, SoftUniRepository>()
    .AddScoped<IEmployeeService, EmployeeService>()
    .BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var service = scope.ServiceProvider.GetService<IEmployeeService>();
var employees = await service.GetEmployeesFromDepartment(7);

foreach (var employee in employees)
{
    Console.WriteLine($"{employee.FirstName} {employee.LastName}, {employee.JobTitle}, {employee.Salary}");
}
