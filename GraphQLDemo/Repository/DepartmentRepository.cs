using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartmentOnly();
        List<Department> GetAllDepartmentsWithEmployee();
        Task<Department> CreateDepartment(Department department);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly GraphQldemoContext _sampleAppDbContext;
        public DepartmentRepository(GraphQldemoContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }
        public List<Department> GetAllDepartmentOnly()
        {
            return _sampleAppDbContext.Departments.ToList();
        }
        public List<Department> GetAllDepartmentsWithEmployee()
        {
            return _sampleAppDbContext.Departments.Include(d => d.Employees).ToList() ?? new();
        }
        public async Task<Department> CreateDepartment(Department department)
        {
            await _sampleAppDbContext.Departments.AddAsync(department);
            await _sampleAppDbContext.SaveChangesAsync();
            return department;
        }
    }
}
