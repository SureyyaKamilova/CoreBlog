using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Please enter role name")]
        public string Name {  get; set; }
    }
}
