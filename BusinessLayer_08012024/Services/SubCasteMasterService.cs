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
    public class SubCasteMasterService : ISubCasteMasterService
    {
        private readonly Connection _connect;
        public SubCasteMasterService(Connection connection)
        {
            this._connect = connection; 
        }
        public async Task AddNewSubCasteMasterData(SubCasteMaster casteMaster)
        {
            if(casteMaster == null)
            {
                throw new BadRequestException("not found");
            }
            else
            {
                await _connect.SubCasteMasterTabb.AddAsync(casteMaster);
                await _connect.SaveChangesAsync();
            }
        }

        public async Task DeleteSubCasteMasterData(Guid id)
        {
            var res=await _connect.SubCasteMasterTabb.FirstOrDefaultAsync(x=>x.SubCasteId==id);
            if(res == null)
            {
                throw new KeyNotFoundException("not found");
            }
            _connect.SubCasteMasterTabb.Remove(res);
            await _connect.SaveChangesAsync();
        }

        public async Task<List<SubCasteMaster>> GetSubCasteMasterData()
        {
            var res = await _connect.SubCasteMasterTabb.Include(x=>x.GotraMasters).ToListAsync();
            return res;
        }

        public async Task UpdateSubCasteMasterData(SubCasteMaster subCasteMaster)
        {
            var res=await _connect.SubCasteMasterTabb.FirstOrDefaultAsync(x=>x.SubCasteId==subCasteMaster.SubCasteId);
            if( res == null)
            {
                throw new KeyNotFoundException("not found");
            }
            res.SubCasteId = subCasteMaster.SubCasteId;
            res.SubCasteName=subCasteMaster.SubCasteName;
            res.Status = subCasteMaster.Status;
            res.Createdby = subCasteMaster.Createdby;
            res.CreatedOn = subCasteMaster.CreatedOn;
            res.ModifiedBy = subCasteMaster.ModifiedBy;
            res.ModifiedOn= subCasteMaster.ModifiedOn;
            _connect.SubCasteMasterTabb.Update(res);
            await _connect.SaveChangesAsync();

        }
    }
}
