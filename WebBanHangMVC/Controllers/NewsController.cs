using WebBanHangMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebBanHangMVC.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
