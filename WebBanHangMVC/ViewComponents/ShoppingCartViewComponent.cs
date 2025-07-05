using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebBanHangMVC.ViewModels; // Giả sử bạn có namespace này
using WebBanHangMVC.Extensions; // Namespace chứa extension Get<T>

namespace WebBanHangMVC.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Lấy giỏ hàng từ Session
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("ShoppingCart");
            int itemCount = cart == null ? 0 : cart.Count;

            return View(itemCount); // Truyền số lượng sản phẩm vào View
        }
    }
}