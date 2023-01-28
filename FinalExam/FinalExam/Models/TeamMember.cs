using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        [StringLength(maximumLength:60)]
        public string Position { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public List<SocialMediaAccount>? SocialMediaAccounts { get; set; }
    }
}
