using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Repository
{
    public class EmployeeRepository
    {
        private readonly GraphQldemoContext _sampleAppDbContext;
        public EmployeeRepository(GraphQldemoContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }
        public List<Employee> GetEmployees()
        {
            return _sampleAppDbContext.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = _sampleAppDbContext.Employees.Include(e => e.Department).Where(e => e.EmployeeId == id).FirstOrDefault();
            if (employee != null) return employee;
            return null;
        }
        public async Task<Employee> UPdateEmployeeByIdAsync(int id, string Name)
        {
            var employee = _sampleAppDbContext.Employees.Include(e => e.Department).Where(e => e.EmployeeId == id).FirstOrDefault();
            employee.Name = Name;
            await _sampleAppDbContext.SaveChangesAsync();
            if (employee != null) return employee;
            return null;
        }
        public List<Employee> GetEmployeesWithDepartment()
        {
            return _sampleAppDbContext.Employees.Include(e => e.Department).ToList();
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _sampleAppDbContext.Employees.AddAsync(employee);
            await _sampleAppDbContext.SaveChangesAsync();
            return employee;
        }
    }
}
