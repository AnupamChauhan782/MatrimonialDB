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
    public class EducationMasterService : IEducationMasterService
    {
        private readonly Connection _connect;
        public EducationMasterService(Connection connection)
        {
            this._connect = connection;
        }
        public async Task AddNewEducationData(EducationMaster educationMaster)
        {
           if(educationMaster == null)
            {
                throw new BadRequestException("not found");
            }
            else
            {
               await _connect.EducationMaasterTabb.AddAsync(educationMaster);
                await _connect.SaveChangesAsync();
            }
        }

        public async Task<EducationMaster> DeleteById(Guid id)
        {
            var res = await _connect.EducationMaasterTabb.FirstOrDefaultAsync(x => x.EducationId == id);
            if(res == null)
            {
                throw new KeyNotFoundException("not found");
            }
             _connect.EducationMaasterTabb.Remove(res);
            await _connect.SaveChangesAsync();
            return res;

        }

        public async Task<List<EducationMaster>> GetAllDataOfEducation()
        {
            var res = await _connect.EducationMaasterTabb.ToListAsync();
            return res;
        }

        public async Task<EducationMaster> GetById(Guid id)
        {
            var res = await _connect.EducationMaasterTabb.FirstOrDefaultAsync(x => x.EducationId == id);
            if(res == null)
            {
                throw new Exception("not found");
            }
            return res;

        }
    }
}
