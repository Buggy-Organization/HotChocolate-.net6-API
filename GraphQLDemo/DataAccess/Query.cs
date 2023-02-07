using GraphQLDemo.Models;
using GraphQLDemo.Repository;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.DataAccess
{
    public class Query
    {
        public List<Employee> AllEmployeeOnly([Service] EmployeeRepository employeeRepository) => employeeRepository.GetEmployees();
        public List<Employee> AllEmployeeWithDepartment([Service] EmployeeRepository employeeRepository) => employeeRepository.GetEmployeesWithDepartment();
        public async Task<Employee> GetEmployeeById([Service] EmployeeRepository employeeRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            Employee gottenEmployee = employeeRepository.GetEmployeeById(id);
            await eventSender.SendAsync("ReturnedEmployee", gottenEmployee);
            return gottenEmployee;
        }
        public async Task<Employee> UpdateEmployeeById([Service] EmployeeRepository employeeRepository,
            [Service] ITopicEventSender eventSender, int id, string name)
        {
            Employee gottenEmployee = await employeeRepository.UPdateEmployeeByIdAsync(id, name);
            await eventSender.SendAsync("ReturnedEmployee", gottenEmployee);
            return gottenEmployee;
        }
        public List<Department> AllDepartmentsOnly([Service] IDepartmentRepository departmentRepository) => departmentRepository.GetAllDepartmentOnly();
        public List<Department> AllDepartmentsWithEmployee([Service] IDepartmentRepository departmentRepository) => departmentRepository.GetAllDepartmentsWithEmployee();
    }
}
