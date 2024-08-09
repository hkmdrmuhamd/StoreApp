using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concreate;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>(); //Product entity'sini döndürmeyi ve diğer solution'lardan ulaşmamızı sağlar.
    public DbSet<Category> Categories => Set<Category>();
    protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed Data oluşturma
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>() //Burada yapılan işlem categori ve product tablolarını bağlamaktır (kesiştişmektir.)
                    .HasMany(e => e.Categories)
                    .WithMany(e => e.Products)
                    .UsingEntity<ProductCategory>();

        modelBuilder.Entity<Category>() //Category tablosundaki url kolonunu unique hale getirir.
                    .HasIndex(u => u.Url)
                    .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new List<Product>() {
                new() { Id=1, Name="Samsung S24", Price=50000, Description="Güzel bir telefon"},
                new() { Id=2, Name="Iphone 11", Price=30000, Description="Güzel bir telefon"},
                new() { Id=3, Name="Samsung S23", Price=40000, Description="Güzel bir telefon"},
                new() { Id=4, Name="Iphone 13", Price=40000, Description="Güzel bir telefon"},
                new() { Id=5, Name="Iphone 14 Pro", Price=55000, Description="Güzel bir telefon"},
                new() { Id=6, Name="Arçelik Çamaşır Makinesi", Price=80000, Description="Güzel bir makine"},
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>() {
                new() { Id=1, Name="Telefon", Url="telefon"},
                new() { Id=2, Name="Elektronik", Url="elektronik"},
                new() { Id=3, Name="Beyaz Eşya", Url="beyaz-esya"},
            }
        );

        modelBuilder.Entity<ProductCategory>().HasData( //Kesişim tablosu
            new List<ProductCategory>()
            {
                new() { ProductId=1, CategoryId=1 },
                new() { ProductId=1, CategoryId=2 },
                new() { ProductId=2, CategoryId=1 },
                new() { ProductId=3, CategoryId=1 },
                new() { ProductId=4, CategoryId=2 },
                new() { ProductId=5, CategoryId=2 },
                new() { ProductId=6, CategoryId=3 }
            }
        );
    }
}