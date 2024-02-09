using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IStateMasterService
    {
        Task<List<StateMaster>> GetAllStateMastersData();
        Task  AddNewStateMasterData(StateMaster newStateMaster);
        Task UpdateNewStateMasterData(StateMaster newStateMaster);
        Task<StateMaster> DeleteNewStateMasterData(Guid id);
    }
}
