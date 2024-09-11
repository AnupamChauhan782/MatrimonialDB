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
    public class DistrictMasterService : IDistrictMasterService
    {
        private readonly Connection _coonection;
        public DistrictMasterService(Connection connection) 
        {
           this._coonection = connection;
        }
        public async Task AddNewDistrictMasterData(DistrictMaster districtMaster)
        {
            try
            {
                if (districtMaster == null)
                {
                    throw new NotFoundException("not found");
                }
                else
                {
                    await _coonection.DistrictMasterTabb.AddAsync(districtMaster);
                    await _coonection.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<DistrictMaster> DeletedDataById(Guid id)
        {
            var res = await _coonection.DistrictMasterTabb.FirstOrDefaultAsync(x => x.DistrictId == id);
            if (res == null)
            {
                throw new KeyNotFoundException("not found");
            }
            _coonection.DistrictMasterTabb.Remove(res);
            await _coonection.SaveChangesAsync();
            return res;

        }

        public async Task<List<DistrictMaster>> GetAllDistrictMasterData()
        {
            try
            {
                var res = await _coonection.DistrictMasterTabb.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DistrictMaster>> GetNewDistrictMasterById(Guid id)
        {
            var res=await _coonection.DistrictMasterTabb.Where(x=>x.StateId==id).ToListAsync();
            if(res == null)
            {
                throw new Exception("not found");
            }
            return res;
        }

        public async Task<DistrictMaster> UpdateDataOfDistrict(DistrictMaster districtMaster)
        {
           var res=await _coonection.DistrictMasterTabb.FirstOrDefaultAsync(x=>x.DistrictId== districtMaster.DistrictId);
            if( res == null)
            {
                throw new BadRequestException("not found");
            }
            res.DistrictId = districtMaster.DistrictId;
            res.DistrictName = districtMaster.DistrictName;
            res.Status = districtMaster.Status;
            res.StateId = districtMaster.StateId;
            res.CreatedBy = districtMaster.CreatedBy;
            res.ModifiedBy = districtMaster.ModifiedBy;
            res.CreatedOn= districtMaster.CreatedOn;
            res.ModifiedOn= districtMaster.ModifiedOn;
            _coonection.DistrictMasterTabb.Update(res);
            await _coonection.SaveChangesAsync();
            return res;

        }

      
    }
}
