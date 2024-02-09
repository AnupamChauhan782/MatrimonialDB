using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IDistrictMasterService
    {
        Task<List<DistrictMaster>> GetAllDistrictMasterData();
        Task  AddNewDistrictMasterData(DistrictMaster districtMaster);
        Task<DistrictMaster> GetNewDistrictMasterById(Guid id);
        Task<DistrictMaster> DeletedDataById(Guid id);
        Task<DistrictMaster>  UpdateDataOfDistrict(DistrictMaster districtMaster);
    }
}
