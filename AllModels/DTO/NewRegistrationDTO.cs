using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.DTO
{
    public class NewRegistrationDTO
    {

        public Guid ProfileID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Religion { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public int? Age { get; set; }
        public float? Height { get; set; }
        public string? Complexion { get; set; }
        public string? HomeLocation { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        [ForeignKey("ImageId")]

        public Guid ImageId { get; set; }





    }
}
