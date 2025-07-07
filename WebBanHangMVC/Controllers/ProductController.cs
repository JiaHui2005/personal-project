using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebBanHangMVC.Models; // Thay YourProjectName bằng namespace của dự án bạn


namespace WebBanHangMVC.Controllers
{
    //[Route("Admin/[controller]")] // Định tuyến cho Controller này
    public class ProductController : Controller
    {
        // Sử dụng dữ liệu giả
        private static List<Product> _products = Product.GetDummyProducts(50); // 50 sản phẩm giả

        public ProductController()
        {
            // Đảm bảo _products được khởi tạo chỉ một lần
            if (_products == null || !_products.Any())
            {
                _products = Product.GetDummyProducts(50);
            }
        }
        public IActionResult Info()
        {
            ViewData["Title"] = "Chi tiết sản phẩm";
            return View(); // tìm tới Views/Product/Info.cshtml
        }

        // GET: /Admin/Products
        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10, string search = "")
        {
            ViewData["Title"] = "Quản lý Sản phẩm";

            // Lọc sản phẩm theo tìm kiếm
            var filteredProducts = _products.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Sắp xếp (ví dụ: theo ID giảm dần)
            filteredProducts = filteredProducts.OrderByDescending(p => p.Id);

            // Phân trang
            int totalProducts = filteredProducts.Count();
            int totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            var productsToShow = filteredProducts
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalProducts = totalProducts;
            ViewBag.SearchTerm = search;

            return View(productsToShow);
        }

        // GET: /Admin/Products/Details/5
        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Chi tiết Sản phẩm";
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: /Admin/Products/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["Title"] = "Thêm Sản phẩm mới";
            return View();
        }

        // POST: /Admin/Products/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Price,StockQuantity,Category,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Gán ID mới (thường là tự động tăng trong DB)
                product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;
                _products.Add(product);
                TempData["SuccessMessage"] = "Sản phẩm đã được thêm thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Admin/Products/Edit/5
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Chỉnh sửa Sản phẩm";
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Admin/Products/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,StockQuantity,Category,ImageUrl,CreatedAt")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = _products.FirstOrDefault(p => p.Id == id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.StockQuantity = product.StockQuantity;
                    existingProduct.Category = product.Category;
                    existingProduct.ImageUrl = product.ImageUrl;
                    existingProduct.UpdatedAt = DateTime.Now; // Cập nhật thời gian cập nhật
                    TempData["SuccessMessage"] = "Sản phẩm đã được cập nhật thành công!";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Admin/Products/Delete/5
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Xóa Sản phẩm";
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Admin/Products/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                TempData["SuccessMessage"] = "Sản phẩm đã được xóa thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
