﻿using FinalExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DashboardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser
            {
                UserName="Admin",
                Fullname= "Nihad Balakisiyev"
            };
            var result = await _userManager.CreateAsync(admin,password:"Admin123");
            return Ok(result);
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1=new IdentityRole("Admin");
            IdentityRole role2=new IdentityRole("Member");
            await _roleManager.CreateAsync(role1);
           var result= await _roleManager.CreateAsync(role2);

            return Ok("Created Roles"+result);
        }

        public async Task<IActionResult> AddRole()
        {
            AppUser admin = await _userManager.FindByNameAsync("Admin");
            var result = await _userManager.AddToRoleAsync(admin, "Admin");
            return Ok("Role created "+result);
        }
    }
}
