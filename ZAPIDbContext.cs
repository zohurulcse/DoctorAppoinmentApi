using System;
using Microsoft.EntityFrameworkCore;


public class ZAPIDbContext : DbContext
{
    public ZAPIDbContext(DbContextOptions<EmployeeDbContext> options)
          : base(options)
    {
        Database.EnsureCreated();
    }
    //public virtual DbSet<Employee> Employees { get; set; }
    //public virtual DbSet<Address> Addresses { get; set; }
    //public virtual DbSet<Customer> Customers { get; set; }
    //public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
}
