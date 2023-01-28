using FinalExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                await _userManager.FindByNameAsync(User.Identity.Name);
            }

            return View(Task.FromResult(user));
        }
    }
}
