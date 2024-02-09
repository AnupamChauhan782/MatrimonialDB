using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IEducationMasterService
    {
        Task<List<EducationMaster>> GetAllDataOfEducation();
        Task AddNewEducationData(EducationMaster educationMaster);
        Task<EducationMaster> GetById(Guid id);
        Task<EducationMaster> DeleteById(Guid id);
    }
}
