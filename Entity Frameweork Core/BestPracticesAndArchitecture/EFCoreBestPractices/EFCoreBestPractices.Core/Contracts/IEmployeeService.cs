using EFCoreBestPractices.Core.Models;

namespace EFCoreBestPractices.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(EmployeeModel model);

        Task<List<EmployeeModel>> GetEmployeesFromDepartment(int departmentId);
    }
}
