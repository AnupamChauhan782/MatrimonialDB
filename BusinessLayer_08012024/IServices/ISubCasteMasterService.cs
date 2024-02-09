using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface ISubCasteMasterService
    {
        Task<List<SubCasteMaster>> GetSubCasteMasterData();
        Task  AddNewSubCasteMasterData(SubCasteMaster casteMaster);
        Task UpdateSubCasteMasterData(SubCasteMaster subCasteMaster);
        Task DeleteSubCasteMasterData(Guid id);
    }
}
