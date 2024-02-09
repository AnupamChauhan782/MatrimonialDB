using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class ProfessionMaster
    {
        [Key]
        public Guid ProfessionId { get; set; }
        [MaxLength(100)]
        public string ProfessionName { get; set; }
        public bool Status { get; set; }
        
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
       
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
