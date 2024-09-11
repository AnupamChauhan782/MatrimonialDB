
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class FileUploadMODEL
    {
        [Key]
        public Guid ImageId { get; set; }
        public string FileUpLoadOne { get; set; }
        public string FileUploadTwo { get; set; }
        public string FileUploadThree { get; set; }
        [ForeignKey("ProfileID")]
        public Guid ProfileID { get; set; }
        public NewRegistrationModel? newRegistrationModel { get; set; }



    }
   
}
