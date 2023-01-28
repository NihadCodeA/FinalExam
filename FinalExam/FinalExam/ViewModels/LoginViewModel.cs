using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels
{
    public class LoginViewModel
    {
        [Required][StringLength(maximumLength:50)]
        public string Username { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
