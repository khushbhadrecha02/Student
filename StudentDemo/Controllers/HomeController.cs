using Microsoft.AspNetCore.Mvc;
using StudentDemo.Models;
using System.Diagnostics;

namespace StudentDemo.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login", "Login", new { area = "Login" });

            }
            return View();  
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}