using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class GotraMaster
    {
        [Key]
        public Guid GotraId { get; set; }
        [Required]
        public string GortaName { get; set; }
        public bool Status { get; set; }
        [ForeignKey("SubCasteId")]
        public Guid SubCasteId { get; set; }
        public SubCasteMaster? CasteMasters { get; set; }
        [MaxLength(100)]
        public string? Createdby { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

    }
}
