using DTOs.ValidateCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AccountDTO
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string FullName { get; set; } = null!;
        [BirthdayCustomer]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int RoleId { get; set; }
        public string? Phone { get; set; }
        public string? BanReason { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public string? Address { get; set; }
        public string? AvatarLink { get; set; }
        public string? Description { get; set; }
        [Required]
        public bool Status { get; set; }

        public virtual RoleDTO Role { get; set; } = null!;
    }
}
