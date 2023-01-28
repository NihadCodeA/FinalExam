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
    }
}
