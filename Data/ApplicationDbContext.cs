using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepairServiceApp.Models;

namespace RepairServiceApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {

        // Таблицы
        public DbSet<Product>? Products { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderExecution>? OrderExecutions { get; set; }
        public DbSet<Malfunction>? Malfunctions { get; set; }
        public DbSet<Review>? Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Вызов базового метода для настройки Identity
            base.OnModelCreating(modelBuilder);

            // Дополнительная настройка сущностей
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderExecution>().ToTable("OrderExecutions");
            modelBuilder.Entity<Malfunction>().ToTable("Malfunctions");
            modelBuilder.Entity<Review>().ToTable("Reviews");
        }
    }
}
