using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Positon { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public List<SocialMediaAccount>? SocialMediaAccounts { get; set; }
    }
}
