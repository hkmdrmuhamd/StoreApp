using StoreApp.Data.Concreate;

namespace StoreApp.Data.Abstract;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; } //Performans açısından daha verimli sorgular yazmak istediğimizde IQueryable kullanmak daha mantıklı olacaktır.
    IQueryable<Category> Categories { get; }
    void CreateProduct(Product entity);
}