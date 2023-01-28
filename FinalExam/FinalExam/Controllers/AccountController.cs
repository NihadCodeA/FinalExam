using FinalExam.Models;
using FinalExam.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View() ;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if(!ModelState.IsValid) return View();
            AppUser user = null;
            user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password incorrect!");
                return View();
            }
           var result = await _signInManager.PasswordSignInAsync(user,loginVM.Password,false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect!");
                return View();
            }
            return RedirectToAction("Index","Home") ;
        }
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                _signInManager.SignOutAsync();
            }
            return RedirectToAction("Login", "Account");
        }
       [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser member = null;

            member = await _userManager.FindByNameAsync(registerVM.Username);
            if (member != null)
            {
                ModelState.AddModelError("Username", "Username has taken!");
                return View();
            }
            
            member = await _userManager.FindByEmailAsync(registerVM.Email);
            if (member != null)
            {
                ModelState.AddModelError("Email", "Email has taken!");
                return View();
            }
            member = new AppUser
            {
                Fullname= registerVM.Fullname,
                Email=registerVM.Email,
                UserName=registerVM.Username,
            };
            var result = await _userManager.CreateAsync(member, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View();
                }
            }
            var roleResult = await _userManager.AddToRoleAsync(member, "Member");
            if (!roleResult.Succeeded)
            {
                foreach (var err in roleResult.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View();
                }
            }
            await _signInManager.SignInAsync(member, isPersistent: false);
            return RedirectToAction("Login", "Account");
        }
    }
}
