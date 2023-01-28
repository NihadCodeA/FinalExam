using FinalExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalExam.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class TeamMemberController : Controller
    {
        private readonly DatabaseContext _context;
        public TeamMemberController(DatabaseContext context) {
        _context= context;
        }
        public IActionResult Index()
        {
            List<TeamMember> teamMembers = _context.TeamMembers.Include(x=>x.SocialMediaAccounts).ToList();
            return View(teamMembers);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamMember teamMember) 
        {
            if (teamMember == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (teamMember.ImageFile != null)
            {

            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image field is required");
                return View();
            }
            return RedirectToAction("Index","Teammember");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(TeamMember teamMember)
        {
            return RedirectToAction("Index", "Teammember");
        }
    }
}
