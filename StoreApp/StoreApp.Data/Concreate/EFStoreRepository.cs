using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;

namespace StoreApp.Data.Concreate;

public class EFStoreRepository : IStoreRepository
{
    private readonly StoreDbContext _context;

    public EFStoreRepository(StoreDbContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Products => _context.Products;
    public IQueryable<Category> Categories => _context.Categories;

    public void CreateProduct(Product entity)
    {
        throw new NotImplementedException();
    }

    public int GetProductCount(string category)
    {
        return category == null
                ? Products.Count() //category null ise direkt olarak tüm sayfaları basar ve buna göre sayfa sayısı oluşur
                : Products // null değilse sadece o kategoriye ait ürün kadar sayfa sayısı oluşur
                          .Include(p => p.Categories)
                          .Where(p => p.Categories
                          .Any(a => a.Url == category))
                          .Count();
    }

    public IEnumerable<Product> GetProductsByCategory(string category, int page, int pageSize)
    {
        var products = Products;

        if (!string.IsNullOrEmpty(category))
        {
            products = products.Include(p => p.Categories).Where(p => p.Categories.Any(a => a.Url == category));
        }

        return products = products.Skip((page - 1) * pageSize).Take(pageSize);
    }
}