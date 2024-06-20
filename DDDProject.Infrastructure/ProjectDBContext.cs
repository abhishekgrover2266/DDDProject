using DDDProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject.Infrastructure
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext() : base()
        {

        }
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
