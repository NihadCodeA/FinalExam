using FinalExam.Helpers;
using FinalExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalExam.Areas.Manage.Controllers
{
        [Area("Manage")]
        [Authorize(Roles = "Admin")]
    public class SocialMediaAccountController : Controller
    {
            private readonly DatabaseContext _context;

            public SocialMediaAccountController(DatabaseContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
            ViewBag.TeamMembers = _context.TeamMembers.ToList();
            List<SocialMediaAccount> smAccounts = _context.SocialMediaAccounts.Include(x => x.TeamMember).ToList();
            return View(smAccounts);
            }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TeamMembers = _context.TeamMembers.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(SocialMediaAccount socialMediaAccount)
        {
            ViewBag.TeamMembers = _context.TeamMembers.ToList();
            if (socialMediaAccount == null) return NotFound();
            if (!ModelState.IsValid) return View();
            
            _context.SocialMediaAccounts.Add(socialMediaAccount);
            _context.SaveChanges();
            return RedirectToAction("Index", "SocialMediaAccount");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.TeamMembers = _context.TeamMembers.ToList();
            SocialMediaAccount socialMediaAccount = _context.SocialMediaAccounts.Include(x=>x.TeamMember).FirstOrDefault(x => x.Id == id);
            if (socialMediaAccount == null) return NotFound();
            return View(socialMediaAccount);
        }
        [HttpPost]
        public IActionResult Update(SocialMediaAccount socialMediaAccount)
        {
            ViewBag.TeamMembers = _context.TeamMembers.ToList();
            SocialMediaAccount existSocialMediaAccount = _context.SocialMediaAccounts.Include(x=>x.TeamMember).FirstOrDefault(x => x.Id == socialMediaAccount.Id);
            if (existSocialMediaAccount == null) return NotFound();
            if (!ModelState.IsValid) return View();

            existSocialMediaAccount.Icon = socialMediaAccount.Icon;
            existSocialMediaAccount.Url = socialMediaAccount.Url;
            _context.SaveChanges();
            return RedirectToAction("Index", "SocialMediaAccount");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            SocialMediaAccount socialMediaAccount = _context.SocialMediaAccounts.FirstOrDefault(x => x.Id == id);
            if (socialMediaAccount == null) return NotFound();
            
            _context.SocialMediaAccounts.Remove(socialMediaAccount);
            _context.SaveChanges();
            return RedirectToAction("Index", "SocialMediaAccount");
        }

    }
}
