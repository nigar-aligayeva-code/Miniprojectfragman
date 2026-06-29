using Microsoft.EntityFrameworkCore;
using MiniProject2.Entities;

namespace MiniProject2.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RSKLB3V\SQLEXPRESS;Database=MiniProject2DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
