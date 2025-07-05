using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebBanHangMVC.Models;

namespace WebBanHangMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult ChinhSachBaoHanh()
    {
        return View();
    }
    public IActionResult HuongDanThanhToan()
    {
        return View();
    }
    public IActionResult ChinhSachDoiTra()
    {
        return View();
    }
    public IActionResult Info()
    {
        return View();
    }
    public IActionResult News()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
