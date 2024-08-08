using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concreate;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>(); //Product entity'sini döndürmeyi ve diğer solution'lardan ulaşmamızı sağlar.
}