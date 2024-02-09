using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class DistrictMaster
    {
        [Key]
        public Guid DistrictId { get; set; }
        [MaxLength(100)]
        [Required]
        public string DistrictName { get; set; }
        public bool Status { get; set; }
        [ForeignKey("StateId")]
        public Guid StateId { get; set; }
        public StateMaster? StateMasters { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
