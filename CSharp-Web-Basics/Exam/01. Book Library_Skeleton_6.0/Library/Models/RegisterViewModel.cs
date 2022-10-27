using Library.Constants;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserConstants.MaxUserName, MinimumLength = UserConstants.MinUserName)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(UserConstants.MaxUserEmail, MinimumLength = UserConstants.MinUserEmail)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.MaxUserPassword, MinimumLength = UserConstants.MinUserPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
