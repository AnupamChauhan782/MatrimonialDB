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
using NotImplementedException = MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions.NotImplementedException;

namespace BusinessLayer_08012024.Services
{
    public class ProfessionMasterSevice : IProfessionMasterService
    {
        private readonly Connection _connect;
        public ProfessionMasterSevice(Connection connection)
        {
            this._connect = connection;   
        }
        public async Task AddNewProfession(ProfessionMaster professionMaster)
        {
            if (professionMaster == null)
            {
                throw new BadRequestException("Not found");
            }
            else
            {
                await _connect.ProfessionTab.AddAsync(professionMaster);
                await _connect.SaveChangesAsync();
            }
        }

        public async Task DeleteProfession(Guid id)
        {
           var res=await _connect.ProfessionTab.FirstOrDefaultAsync(x=>x.ProfessionId== id);
            if(res == null)
            {
                throw new KeyNotFoundException("Not Found any Professon");
            }
            _connect.ProfessionTab.Remove(res);
            await _connect.SaveChangesAsync();
        }

        public async Task<ProfessionMaster> GetByIdProfessionMaster(Guid id)
        {
            var res=await _connect.ProfessionTab.FirstOrDefaultAsync(x=>x.ProfessionId == id);
            if (res == null)
            {
                throw new NotImplementedException("not found profession of this id");
            }
            return res;
        }

        public async Task<List<ProfessionMaster>> GetProfessionMaster()
        {
            var res = await _connect.ProfessionTab.ToListAsync();
            return res;
        }

        public async Task<ProfessionMaster> UpdateProfessionMaster(ProfessionMaster professionMaster)
        {
           var res=await _connect.ProfessionTab.FirstOrDefaultAsync(x=>x.ProfessionId== professionMaster.ProfessionId);
            if( res == null)
            {
                throw new KeyNotFoundException("not found to data for update");
            }
            res.ProfessionId= professionMaster.ProfessionId;
            res.ProfessionName= professionMaster.ProfessionName;
            res.Status= professionMaster.Status;
            res.CreatedBy= professionMaster.CreatedBy;
            res.ModifiedBy= professionMaster.ModifiedBy;
            res.ModifiedOn= professionMaster.ModifiedOn;
            res.CreatedOn= professionMaster.CreatedOn;
            _connect.ProfessionTab.Update(res);
            await _connect.SaveChangesAsync();
            return res;

        }
    }
}
