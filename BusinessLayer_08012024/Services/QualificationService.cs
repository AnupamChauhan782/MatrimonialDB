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
    public class QualificationService : IQualificationService
    {
        private readonly Connection _connect;
        public QualificationService(Connection connection)
        {
            this._connect = connection; 
        }
        public async Task AddQualification(QualificationMaster qualificationMaster)
        {
             if (qualificationMaster == null)
            {
                throw new BadRequestException("not found");
            }
            else
            {
                await _connect.QualificationTabb.AddAsync(qualificationMaster);
                await _connect.SaveChangesAsync();
            }
        }

        public async Task<QualificationMaster> DeleteQyalication(Guid id)
        {
            var res=await _connect.QualificationTabb.FirstOrDefaultAsync(x=>x.QualificationId == id);
            if (res == null)
            {
                throw new KeyNotFoundException("not found Qualification Data");
            }
            _connect.QualificationTabb.Remove(res);
            await _connect.SaveChangesAsync();
            return res;
        }

        public async Task<List<QualificationMaster>> GetAllQualification()
        {
            var res = await _connect.QualificationTabb.ToListAsync();
            return res;
        }

        public async Task<QualificationMaster> UpdateQualication(QualificationMaster qualificationMaster)
        {
           var res=await _connect.QualificationTabb.FirstOrDefaultAsync(x=>x.QualificationId==qualificationMaster.QualificationId);
            if(res == null)
            {
                throw new KeyNotFoundException("This data is not exits");
            }
            res.QualificationId = qualificationMaster.QualificationId;
            res.QualificationName = qualificationMaster.QualificationName;
            res.Status = qualificationMaster.Status;
            res.ModifiedBy = qualificationMaster.ModifiedBy;
            res.CreatedBy = qualificationMaster.CreatedBy;
            res.CreatedOn = qualificationMaster.CreatedOn;
            res.ModifiedOn = qualificationMaster.ModifiedOn;
            _connect.QualificationTabb.Update(res);
            await _connect.SaveChangesAsync() ;
            return res;
        }
    }
}
