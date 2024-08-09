using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class HomeController : Controller
{
    public int pageSize = 3; //Sayfa başına gösterilecek ürün sayısı
    private readonly IStoreRepository _storeRepository;
    public HomeController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    public IActionResult Index(int page = 1)
    {
        var products = _storeRepository
        .Products
        .Skip((page - 1) * pageSize) //Database'deki kayıtları öteleme işlemidir.(Örneğin sayfa 2 olduğunda ilk 3 kaydı atlar ve sonraki 3 kaydı gösterir)
        .Select(p =>
            new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category
            }).Take(pageSize);

        return View(new ProductListViewModel
        {
            Products = products
        });
    }

}