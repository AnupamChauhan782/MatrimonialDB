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
    public class StateMasterService : IStateMasterService
    {
        private readonly Connection _connection;

        public StateMasterService(Connection connection) 
        {
           this._connection = connection;

        }
        public async Task AddNewStateMasterData(StateMaster newStateMaster)
        {
            try
            {
                if(newStateMaster == null)
                {
                    throw new BadRequestException("not found");
                }
                else
                {
                    await _connection.StateMasterTabb.AddAsync(newStateMaster);
                    await _connection.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<StateMaster> DeleteNewStateMasterData(Guid id)
        {
            var res=await _connection.StateMasterTabb.FirstOrDefaultAsync(x=>x.StateId == id);
            if(res == null)
            {
                throw new KeyNotFoundException("not found");
            }
            _connection.StateMasterTabb.Remove(res);
            await _connection.SaveChangesAsync();
            return res;
        }

        public async Task<List<StateMaster>> GetAllStateMastersData()
        {
            try
            {
                var res = await _connection.StateMasterTabb.Include(x=>x.DistrictMasters).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StateMaster>> GetNewStateById(Guid id)
        {
           var res=await _connection.StateMasterTabb.Where(x=>x.CountryId==id).ToListAsync();
            if(res == null)
            {
                throw new KeyNotFoundException("this id is not found");
            }
            return res;
        }

        public async Task UpdateNewStateMasterData(StateMaster newStateMaster)
        {
            var res=await _connection.StateMasterTabb.FirstOrDefaultAsync(x=>x.StateId==newStateMaster.StateId);
            if( res == null)
            {
                throw new KeyNotFoundException("not found");
            }
            res.StateId = newStateMaster.StateId;
            res.StateName = newStateMaster.StateName;
            res.Status = newStateMaster.Status;
            res.CountryId = newStateMaster.CountryId;
            res.CreatedBy = newStateMaster.CreatedBy;
            res.CreatedOn = newStateMaster.CreatedOn;
            res.ModifiedOn = newStateMaster.ModifiedOn;
            res.ModifiedBy = newStateMaster.ModifiedBy;
            _connection.StateMasterTabb.Update(res);
            await _connection.SaveChangesAsync();

        }
    }
}
