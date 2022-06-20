

using System.ComponentModel.DataAnnotations;

namespace FA.LegalHCM.WebAPI.Endpoints.Users
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
