using AllModels.DTO;

using AllModels.Model;

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.helper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CountryMaster,CountryMasterDto>().ReverseMap();

            CreateMap<StateMaster,StateMasterDto>().ReverseMap();

            CreateMap<DistrictMaster,DistrictMasterDto>().ReverseMap();

            CreateMap<SubCasteMaster,SubCasteMasterDto>().ReverseMap();   

            CreateMap<GotraMaster,GotraMasterDto>().ReverseMap();   

            CreateMap<EducationMaster,EducationMasterDto>().ReverseMap();

            CreateMap<Enquiry,EnquiryDto>().ReverseMap();   

            CreateMap<ProfessionMaster,ProfessionMasterDto>().ReverseMap(); 

            CreateMap<QualificationMaster,QualificationMasterDto>().ReverseMap();

            CreateMap<FileUploadMODEL,FileUploadDTO>().ReverseMap();

            CreateMap<UserModel,UserModelDTO>().ReverseMap();

            CreateMap<LoginModel,LoginModelDTO>().ReverseMap();

            CreateMap<NewRegistrationModel,NewRegistrationDTO>().ReverseMap();  
            

     
        }
    }
}
