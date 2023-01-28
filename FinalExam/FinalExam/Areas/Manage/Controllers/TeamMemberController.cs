using FinalExam.Helpers;
using FinalExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _env;
        
        public TeamMemberController(DatabaseContext context,IWebHostEnvironment env) {
            _context= context;
            _env= env;
        }
        public IActionResult Index(int page=1)
        {
            List<TeamMember> teamMembers = _context.TeamMembers.Include(x=>x.SocialMediaAccounts).ToList();
            //var query = _context.SocialMediaAccounts.Include(x => x.TeamMember).AsQueryable();
            //var items = PaginatedList<SocialMediaAccount>.Create(query, page, 3);
            //return View(items);
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
                teamMember.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/teams", teamMember.ImageFile);
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image field is required");
                return View();
            }
            _context.TeamMembers.Add(teamMember);   
            _context.SaveChanges();
            return RedirectToAction("Index","Teammember");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            TeamMember teamMember= _context.TeamMembers.Include(x => x.SocialMediaAccounts).FirstOrDefault(x=>x.Id==id);
            if (teamMember == null) return NotFound();
            return View(teamMember);
        }
        [HttpPost]
        public IActionResult Update(TeamMember teamMember)
        {
            TeamMember existTeamMember = _context.TeamMembers.Include(x => x.SocialMediaAccounts).FirstOrDefault(x => x.Id == teamMember.Id);
            if (existTeamMember == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (teamMember.ImageFile != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/teams", existTeamMember.Image);
                existTeamMember.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/teams", teamMember.ImageFile);
            }
            existTeamMember.FullName = teamMember.FullName;
            existTeamMember.Order = teamMember.Order;
            existTeamMember.Position = teamMember.Position;
            existTeamMember.FullName = teamMember.FullName;
            _context.SaveChanges();
            return RedirectToAction("Index", "Teammember");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TeamMember teamMember = _context.TeamMembers.Include(x => x.SocialMediaAccounts).FirstOrDefault(x => x.Id == id);
            if (teamMember == null) return NotFound();
            if (teamMember.Image != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/teams", teamMember.Image);
            }
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
            return RedirectToAction("Index", "Teammember");
        }

    }
}
