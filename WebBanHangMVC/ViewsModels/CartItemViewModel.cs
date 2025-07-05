// File: YourProjectName/ViewModels/CartItemViewModel.cs
namespace WebBanHangMVC.ViewModels // Đảm bảo namespace này đúng với tên project của bạn
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
    }
}