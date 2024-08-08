using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concreate;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>(); //Product entity'sini döndürmeyi ve diğer solution'lardan ulaşmamızı sağlar.

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed Data oluşturma
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new List<Product>() {
                new() { Id=1, Name="Samsung S24", Price=50000, Description="Güzel bir telefon", Category="Telefon"},
                new() { Id=2, Name="Iphone 11", Price=30000, Description="Güzel bir telefon", Category="Telefon"},
                new() { Id=3, Name="Samsung S23", Price=40000, Description="Güzel bir telefon", Category="Telefon"},
                new() { Id=4, Name="Iphone 13", Price=40000, Description="Güzel bir telefon", Category="Telefon"},
                new() { Id=5, Name="Iphone 14 Pro", Price=55000, Description="Güzel bir telefon", Category="Telefon"},
                new() { Id=6, Name="Iphone 15 Pro Max", Price=80000, Description="Güzel bir telefon", Category="Telefon"},
            }
        );
    }
}