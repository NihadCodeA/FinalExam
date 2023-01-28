using Microsoft.AspNetCore.Identity;

namespace FinalExam.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
