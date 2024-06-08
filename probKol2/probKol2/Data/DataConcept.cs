using Microsoft.EntityFrameworkCore;
using probKol2.Models;

namespace probKol2.Data;

public class DataConcept: DbContext
{

    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees  { get; set; }
    public DbSet<Order> Orders   { get; set; }
    public DbSet<Pastry> Pastries    { get; set; }
    public DbSet<OrderPastry> OrderPastries { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>().HasData(new List<Client>()
        {
            new () { ID = 1, FirstName = "Ala", LastName = "Kowalska"},
            new () { ID = 2, FirstName = "Zosia", LastName = "Nowak"}
        });
        modelBuilder.Entity<Pastry>().HasData(new List<Pastry>()
        {
        new () {ID = 1, Name = "cola", Price = 12, Type = "cosTam"},
        new () {ID = 2, Name = "pepsi", Price = 1.1, Type = "xxx"}
        });

        modelBuilder.Entity<Employee>().HasData(new List<Employee>()
        {
            new () {ID = 1, FirstName = "ala", LastName = "kowalas"},
            new () {ID = 2, FirstName = "kuba", LastName = "kusoa"}
        });
        
        modelBuilder.Entity<Order>().HasData(new List<Order>()
        {
            new () {ID = 1, AcceptedAt = DateTime.Now, FuffilledAt = DateTime.Now, Comments = "dasd", ClientId = 1, EmployeeID =2 },
            new () {ID = 2, AcceptedAt = DateTime.Now, FuffilledAt = DateTime.Now, Comments = "ads", ClientId = 2, EmployeeID =2 }
        });
        
        modelBuilder.Entity<OrderPastry>().HasData(new List<OrderPastry>()
        {
            new () { OrderID = 1, PastryID = 1, Amount = 12, Comme = "dasda"},
            new () { OrderID = 1, PastryID = 2, Amount = 11, Comme = "xxx"}
        });
        

    }
    
    
}