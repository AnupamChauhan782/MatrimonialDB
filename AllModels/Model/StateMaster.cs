using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class StateMaster
    {
        [Key]
        public Guid StateId { get; set; }

        [Required(ErrorMessage = "Enter valid Information")]
        [MaxLength(100)]
        public string StateName { get; set; }
        public bool Status { get; set; }

        public Guid CountryId { get; set; }
        public CountryMaster? CountryMasters { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public ICollection<DistrictMaster> DistrictMasters { get; set; } = new List<DistrictMaster>();

    }
}
