using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AspNetCoreProject1.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-50T6SSM\\SQLEXPRESS; database=CoreEmployee;" +
                "integrated security=true;TrustServerCertificate=True;");
        }


        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        // public DbSet<Department> Departments { get; set; } -> "DbSet<>" içerisindeki bizim Classımız
        // "Departments" ise bizim classımızı tutan veri tabanındaki tablomuz
        public DbSet<Admin> Admins { get; set; }
    }
}
