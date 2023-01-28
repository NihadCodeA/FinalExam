using FinalExam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}