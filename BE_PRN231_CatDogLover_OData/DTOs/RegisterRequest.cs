using DTOs.ValidateCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).{8,})",
    ErrorMessage = "The new password must have all of these conditions: " +
    "\n-At least 8 characters" +
    "\n-Contains a lowercase, a uppercase and a special character")]
        [MaxLength(50, ErrorMessage = "Max length of password is 50")]
        public string Password { get; set; } = null!;
        [Required]
        public string PasswordConfirm { get; set; } = null!;
        [Required]
        public string FullName { get; set; } = null!;
        [BirthdayCustomer]
        public DateTime? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? AvatarLink { get; set; }
        public string? Description { get; set; }
    }
}
