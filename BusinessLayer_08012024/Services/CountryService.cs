using AllModels.Model;
using BusinessLayer_08012024.IServices;
using DataAccessLayer_08012024.DbConnection;
using MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyNotFoundException = MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions.KeyNotFoundException;

namespace BusinessLayer_08012024.Services
{
    public class CountryService : ICountryMasterService
    {
        private readonly Connection _connect;
        public CountryService(Connection connection) 
        {
          this._connect = connection;
        }
        public async Task AddNewCountryMasterData(CountryMaster countryMaster)
        {
            try
            {
                if(countryMaster == null)
                {
                    throw new BadRequestException("not found");
                }
                else
                {
                    await _connect.CountryMasterTabb.AddAsync(countryMaster);
                    await _connect.SaveChangesAsync();
                }
               
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CountryMaster> DeletedDataOfCountryMaster(Guid id)
        {
           var res=await _connect.CountryMasterTabb.FirstOrDefaultAsync(x=>x.CountryId == id);
            if(res == null)
            {
                throw new KeyNotFoundException("not found to this key");
            }
             _connect.CountryMasterTabb.Remove(res);
            await _connect.SaveChangesAsync();
            return res;
        }

        public async Task<List<CountryMaster>> GetAllDataOfCountryMaster()
        {
            try
            {
                var res = await _connect.CountryMasterTabb.Include(x=>x.StateMasters).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<CountryMaster> GetCountryById(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpDateDataOfCountryMaster(CountryMaster countryMaster)
        {
           var res=await _connect.CountryMasterTabb.FirstOrDefaultAsync(x=>x.CountryId==countryMaster.CountryId);
            if(res == null)
            {
                throw new NotFoundException("not found to this key");
            }
            res.CountryId = countryMaster.CountryId;
            res.CountryName = countryMaster.CountryName;
            res.Status = countryMaster.Status;
             _connect.CountryMasterTabb.Update(res);
            await _connect.SaveChangesAsync();
        }
    }
}
