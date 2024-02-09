using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.DTO
{
    public class QualificationMasterDto
    {
        public Guid QualificationId { get; set; }
        [MaxLength(100)]
        
        public string QualificationName { get; set; }
        public bool Status { get; set; }
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
