using Microsoft.AspNetCore.Mvc;
using WebBanHangMVC.ViewModels;
using WebBanHangMVC.Extensions;
using WebBanHangMVC.Models;

namespace WebBanHangMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
