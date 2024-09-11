using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class NewRegistrationModel
    {
        [Key]
        public Guid ProfileID { get; set; }
       
       
        [MaxLength(100)]
        public string Religion { get; set; }
        [MaxLength(100)]
        public string? MaritalStatus { get; set; }
        public int? Age { get; set; }
        public float? Height { get; set; }
        public string? location { get; set; }
        public string Caste { get; set; }
        public string? Complexion { get; set; }
        public string? HomeLocation { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

      
        public Guid CountryId { get; set; }
        public Guid DistrictId { get; set; }

        public Guid EnqId { get; set; }

        public Guid GotraId { get; set; }

        public Guid ProfessionId { get; set; }

        public Guid QualificationId { get; set; }

        public Guid StateId { get; set; }

        public Guid SubCasteId { get; set; }
        public ICollection<FileUploadMODEL> fileUpload { get; set; } = new List<FileUploadMODEL>();


    }
}
