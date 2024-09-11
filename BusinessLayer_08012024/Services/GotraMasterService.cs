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
    public class GotraMasterService : IGotraMasterService
    {
        private readonly Connection _connect;
        public GotraMasterService(Connection connection) 
        {
          this._connect = connection;
        }
        public async Task AddNewGotraMasterData(GotraMaster gotraMaster)
        {
            if(gotraMaster == null)
            {
                throw new BadRequestException("not found");
            }
            else
            {
                await _connect.GotraMasterTabb.AddAsync(gotraMaster);
                await _connect.SaveChangesAsync();
            }
        }

        public async Task<GotraMaster> DeleteData(Guid id)
        {
            var res=await _connect.GotraMasterTabb.FirstOrDefaultAsync(x=>x.GotraId == id);
            if(res == null)
            {
                throw new KeyNotFoundException("not found");
            }
            _connect.GotraMasterTabb.Remove(res);
            await _connect.SaveChangesAsync() ;
            return res;
        }

        public async Task<List<GotraMaster>> GetGotraMasterById(Guid id)
        {
           var res=await _connect.GotraMasterTabb.Where(x=>x.SubCasteId==id).ToListAsync();
            if( res == null)
            {
                throw new KeyNotFoundException("not found");
            }
            return res;
        }

        public async Task<List<GotraMaster>> GetGotraMasterData()
        {
            var res = await _connect.GotraMasterTabb.ToListAsync();
            return res;
        }

        public async Task<GotraMaster> UpadateData(GotraMaster gotraMaster)
        {
           var res=await _connect.GotraMasterTabb.FirstOrDefaultAsync(x=>x.GotraId==gotraMaster.GotraId);
            if( (res == null))
            {
                throw new KeyNotFoundException("This data is not exits");
            }
            res.GotraId = gotraMaster.GotraId;
            res.GortaName = gotraMaster.GortaName;
            res.Status = gotraMaster.Status;
            res.Createdby = gotraMaster.Createdby;
            res.CreatedOn = gotraMaster.CreatedOn;
            res.ModifiedBy = gotraMaster.ModifiedBy;
            res.ModifiedOn = gotraMaster.ModifiedOn;
            res.SubCasteId = gotraMaster.SubCasteId;
            _connect.GotraMasterTabb.Update(res);
            await _connect.SaveChangesAsync();
            return res;
        }
    }
}
