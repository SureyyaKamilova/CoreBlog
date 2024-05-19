using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Please, Enter UserName")]
        public string username {  get; set; }

        [Required(ErrorMessage = "Please, Enter Password")]
        public string password { get; set; }
    }
}
