using AllModels.DTO;
using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface INewRegistrationService
    {
        Task<List<NewRegistrationModel>> NewRegistrationData();
        Task<NewRegistrationModel> AddNewRegistrationData(NewRegistrationModel newRegistration);

        Task<NewRegistrationModel>  DeleteNewRegistrationData(Guid id);

        Task<NewRegistrationModel> UpdateNewRegistration(NewRegistrationModel newRegistration);

        Task<Object> GetAllNewREgistration();
    }
}
