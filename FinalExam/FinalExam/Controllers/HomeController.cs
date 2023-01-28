using FinalExam.Models;
using FinalExam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext context) 
        {
            _context=context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                TeamMembers=_context.TeamMembers.Include(x=>x.SocialMediaAccounts).OrderBy(x=>x.Order).Take(3).ToList(),
                SocialMediaAccounts=_context.SocialMediaAccounts.OrderByDescending(x=>x.Id).Take(4).ToList(),
            };
            return View(homeVM);
        }

    }
}