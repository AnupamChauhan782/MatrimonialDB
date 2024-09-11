using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IGotraMasterService
    {
        Task<List<GotraMaster>> GetGotraMasterData();
        Task AddNewGotraMasterData(GotraMaster gotraMaster);
        Task<List<GotraMaster>> GetGotraMasterById(Guid id);
        Task<GotraMaster>  DeleteData(Guid id);
        Task<GotraMaster>  UpadateData(GotraMaster gotraMaster);
    }
}
