using EFCoreBestPractices.Core.Contracts;
using EFCoreBestPractices.Core.Models;
using EFCoreBestPractices.Infrastructure.Data.Common;
using EFCoreBestPractices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBestPractices.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISoftUniRepository repo;

        public EmployeeService(ISoftUniRepository _repo)
        {
            repo = _repo;
        }

        public Task<int> AddEmployee(EmployeeModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeModel>> GetEmployeesFromDepartment(int departmentId)
        {
            return await repo.AllReadonly<Employee>()
                .Where(e => e.DepartmentId == departmentId)
                .Select(e => new EmployeeModel()
                {
                    FirstName = e.FirstName,
                    HireDate = e.HireDate,
                    Id = e.EmployeeId,
                    JobTitle = e.JobTitle,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    Salary = e.Salary
                }).ToListAsync();
        }
    }
}
