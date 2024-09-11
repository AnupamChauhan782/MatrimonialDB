using AllModels.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.DTO
{
    public class FileUploadDTO
    {
        public Guid ImageId { get; set; }
        public string FileUpLoadOne { get; set; }
        public string FileUploadTwo { get; set; }
        public string FileUploadThree { get; set; }

        public Guid ProfileID { get; set; }
        public NewRegistrationModel? newRegistrationModel { get; set; }


    }
}
