using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IProfessionMasterService
    {
        Task<List<ProfessionMaster>> GetProfessionMaster();
        Task AddNewProfession(ProfessionMaster professionMaster);
        Task DeleteProfession(Guid id);
        Task<ProfessionMaster> UpdateProfessionMaster(ProfessionMaster professionMaster);
        Task<ProfessionMaster>  GetByIdProfessionMaster(Guid id);
    }
}
