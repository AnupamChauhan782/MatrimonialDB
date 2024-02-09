using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class Enquiry
    {
        [Key]
        public Guid EnqId { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        public string? PhoneNo { get; set; }
        public string Email { get; set; }
        public string? Gender { get; set; }
        public DateTime DOB { get; set; }
        [MaxLength(50)]
        public string? EnquiyFor { get; set; }
        public bool? Status { get; set; }
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
