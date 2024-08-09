using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public IActionResult Index(string category, int page = 1)
    {
        ;
        return View(new ProductListViewModel
        {
            Products = _storeRepository.GetProductsByCategory(category, page, pageSize).Select(p =>
                    new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                    }),
            PageInfo = new PageInfo
            {
                TotalItems = _storeRepository.GetProductCount(category),
                ItemsPerPage = pageSize,
                CurrentPage = page
            }
        }
        );
    }

}