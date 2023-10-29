using BusinessObjects;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ReportDTO
    {
        public int ReporterId { get; set; }
        public int ReportedPersonId { get; set; }
        public string? Content { get; set; }

        public virtual AccountDTO ReportedPerson { get; set; } = null!;
        public virtual AccountDTO Reporter { get; set; } = null!;
    }
}
