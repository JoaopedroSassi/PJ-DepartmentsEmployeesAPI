using DepartmentsCompanies.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentsCompanies.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
