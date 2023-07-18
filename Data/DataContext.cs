using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-71UULJJ\\SQLEXPRESS;Database=EmployeeMgmntSystem;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<DepartmentModel> DepartmentModels { get; set; }


    }
}
