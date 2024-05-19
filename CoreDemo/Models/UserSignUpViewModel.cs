using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="FullName")]
        [Required(ErrorMessage ="Please,Enter Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please,Enter Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "Password are not compatible")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E mail ")]
        [Required(ErrorMessage = "Please,Enter Mail")]
        public string Mail { get; set; }

        [Display(Name = "UserName ")]
        [Required( ErrorMessage = "Please,Enter UserName")]
        public string UserName { get; set; }

    }
}
