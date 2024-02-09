using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface ICountryMasterService
    {
        Task<List<CountryMaster>> GetAllDataOfCountryMaster();
        Task  AddNewCountryMasterData(CountryMaster countryMaster);
        Task<CountryMaster> DeletedDataOfCountryMaster(Guid id);
        Task  UpDateDataOfCountryMaster(CountryMaster countryMaster);
    }
}
