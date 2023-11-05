using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class GiftCommentDTO
    {
        [Key]
        public int GiftCommentId { get; set; }
        public string GiftId { get; set; } = null!;
        [Required]
        public int AccountId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string ApproveStatus { get; set; } = null!;

        public virtual AccountDTO Account { get; set; } = null!;
    }
}
