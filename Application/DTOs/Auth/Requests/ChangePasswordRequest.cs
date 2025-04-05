using System.ComponentModel.DataAnnotations;

namespace TakeLeaveMngSystem.Application.DTOs.Auth.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        public string? NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
