namespace FinalExam.Models
{
    public class SocialMediaAccount
    {
        public int Id { get; set; }
        public int? TeamMemberId { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        public TeamMember? TeamMember { get; set; }
    }
}
