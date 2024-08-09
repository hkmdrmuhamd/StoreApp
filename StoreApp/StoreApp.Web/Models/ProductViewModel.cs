namespace StoreApp.Web.Models;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class ProductListViewModel //Product bilgisini list şekilnde göndermemizi sağlar.
{
    public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    public PageInfo PageInfo { get; set; } = new();
}

public class PageInfo
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); //Toplam oluşturulacak sayfa sayısı (kesirli değerler çıktığında bunu bir üst değere yuvarlar)
}