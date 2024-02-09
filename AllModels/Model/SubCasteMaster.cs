using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class SubCasteMaster
    {
        [Key]
        public Guid SubCasteId { get; set; }
        [Required]
        public string SubCasteName { get; set; }
        public bool Status { get; set; }
        [MaxLength(100)]
        public string? Createdby { get; set; }
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }=DateTime.Now;
        public ICollection<GotraMaster> GotraMasters { get; set; }=new List<GotraMaster>();
    }
}
