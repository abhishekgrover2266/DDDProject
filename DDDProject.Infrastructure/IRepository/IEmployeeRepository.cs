using DDDProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject.Infrastructure.IRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(Employee emp);
        Task UpdateAsync(Employee emp);
        Task DeleteAsync(int id);
    }
}
