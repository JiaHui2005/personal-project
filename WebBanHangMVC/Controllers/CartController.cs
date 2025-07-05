using Microsoft.AspNetCore.Mvc;
using WebBanHangMVC.ViewModels;
using WebBanHangMVC.Extensions;
using WebBanHangMVC.Models;
public class CartController : Controller
{
    public IActionResult Index()
    {
        var fakeCart = new List<CartItem>
        {
            new CartItem { ProductId = 1, ProductName = "PC Faster Gaming 10400F - RTX 3050 6GB (All New - Bộ hoàn)", Quantity = 2, Price = 10000, ImageUrl = "\\Image\\test.jpg" },
            new CartItem { ProductId = 2, ProductName = "Sản phẩm 2", Quantity = 1, Price = 20000, ImageUrl = "\\Image\\test.jpg" },
            new CartItem { ProductId = 3, ProductName = "Sản phẩm 3", Quantity = 3, Price = 15000, ImageUrl = "\\Image\\test.jpg" }
        };

        return View(fakeCart);
    }
}