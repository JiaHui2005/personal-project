// File: YourProjectName/ViewModels/CartViewModel.cs
using System.Collections.Generic;
using System.Linq;

namespace WebBanHangMVC.ViewModels // Đảm bảo namespace này đúng với tên project của bạn
{
    public class CartViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
        public decimal Subtotal => CartItems.Sum(item => item.Total);
        public decimal ShippingFee { get; set; } = 0;
        public decimal GrandTotal => Subtotal + ShippingFee;
    }
}