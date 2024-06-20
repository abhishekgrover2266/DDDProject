using DDDProject.Domain;
using DDDProject.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject.Infrastructure.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly ProjectDBContext _dbContext;

        public EmployeeRepository(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task AddAsync(Employee emp)
        {
            await _dbContext.Employees.AddAsync(emp);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee emp)
        {
            _dbContext.Entry(emp).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
