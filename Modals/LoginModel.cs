using System.ComponentModel.DataAnnotations;

namespace NajotTalim.HR.API.Modals
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
