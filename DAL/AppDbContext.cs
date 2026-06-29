using Microsoft.EntityFrameworkCore;
using MiniProject2.Entities;

namespace MiniProject2.DAL
{
    public class AppDbContext : DbContext
    {
        // Bu hissə SQL-də cədvəllərimizin yaranmasını təmin edir
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Kompüterinizdəki SQL Server-ə qoşulmaq üçün bağlantı mətni (ConnectionString).
            // Server=. hissəsi sizin lokal SQL Serverinizə işarə edir.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RSKLB3V\SQLEXPRESS;Database=MiniProject2DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}