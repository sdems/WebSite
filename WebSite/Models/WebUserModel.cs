using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class WebUserModel
    {
        [Display(Name = "Email :")]
        public string Email { get; set; }
        [Display(Name = "Login :")]
        public string Login { get; set; }
        [Display(Name = "Password :")]
        public string Password { get; set; }
        [Display(Name = "Remember me :")]
        public bool RememberMe { get; set; }
    }
}