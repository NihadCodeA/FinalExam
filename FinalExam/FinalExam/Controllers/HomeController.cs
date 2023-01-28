using FinalExam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(DatabaseContext c) { }
        public IActionResult Index()
        {
            
            return View();
        }

    }
}