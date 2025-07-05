using System.ComponentModel.DataAnnotations;

namespace WebBanHangMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Tên sản phẩm phải có từ 3 đến 200 ký tự.")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc.")]
        [Range(0.01, 1000000000.00, ErrorMessage = "Giá phải lớn hơn 0.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng tồn kho")]
        [Range(0, 100000, ErrorMessage = "Số lượng không hợp lệ.")]
        public int StockQuantity { get; set; }

        [Display(Name = "Danh mục")]
        [StringLength(50, ErrorMessage = "Danh mục không được vượt quá 50 ký tự.")]
        public string Category { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public string ImageUrl { get; set; } // Đường dẫn URL tới ảnh sản phẩm

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Dữ liệu giả (không nên dùng trong production, chỉ để minh họa)
        public static List<Product> GetDummyProducts(int count = 25)
        {
            var products = new List<Product>();
            var random = new Random();
            var categories = new[] { "Điện thoại", "Laptop", "Phụ kiện", "Thiết bị nhà thông minh", "Thiết bị đeo tay" };
            var productNames = new[]
            {
                "Samsung Galaxy S24 Ultra", "iPhone 15 Pro Max", "Xiaomi 14", "Oppo Reno 11F", "MacBook Air M3",
                "Dell XPS 15", "HP Spectre x360", "Tai nghe Sony WH-1000XM5", "Apple Watch Series 9",
                "Google Nest Hub 2", "Camera Imou Ranger 2", "Sạc dự phòng Anker 20000mAh",
                "Bàn phím cơ Akko 3098B", "Chuột Logitech MX Master 3S", "Màn hình Dell UltraSharp U2723QE"
            };

            for (int i = 1; i <= count; i++)
            {
                var name = productNames[random.Next(productNames.Length)];
                var category = categories[random.Next(categories.Length)];
                var price = Math.Round((decimal)(random.NextDouble() * (100000000 - 500000) + 500000), 0); // 500k to 100M VND
                var stock = random.Next(0, 500); // 0 to 500 items
                var description = $"Mô tả chi tiết cho sản phẩm {name}. Đây là sản phẩm thuộc danh mục {category} với nhiều tính năng nổi bật.";

                products.Add(new Product
                {
                    Id = i,
                    Name = name + (i > productNames.Length ? $" {i - productNames.Length}" : ""), // Add suffix if repeating names
                    Description = description,
                    Price = price,
                    StockQuantity = stock,
                    Category = category,
                    ImageUrl = $"https://picsum.photos/id/{100 + i}/200/200", // Example image URL
                    CreatedAt = DateTime.Now.AddDays(-random.Next(1, 365)),
                    UpdatedAt = DateTime.Now.AddDays(-random.Next(0, 30))
                });
            }
            return products;
        }
    }
}
