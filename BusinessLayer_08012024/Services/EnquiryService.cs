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
    public class EnquiryService : IEnquiryService
    {
        private readonly Connection _connect;
        public EnquiryService(Connection connect)
        {
            this._connect = connect;
        }
        public async Task AddNewEnquiry(Enquiry enquiry)
        {
            if(enquiry == null)
            {
                throw new BadRequestException("not found");
            }
            else
            {
                await _connect.EnquiryTables.AddAsync(enquiry);
                await _connect.SaveChangesAsync();
            }
        }

        public async Task<Enquiry> DeleteEnquiry(Guid id)
        {
          var res=await _connect.EnquiryTables.FirstOrDefaultAsync(x=>x.EnqId==id);
            if(res == null)
            {
                throw new KeyNotFoundException("not found");
            }
           _connect.EnquiryTables.Remove(res);
            await _connect.SaveChangesAsync() ;
            return res;
        }

        public async Task<List<Enquiry>> GetEnquiryList()
        {
           var res=await _connect.EnquiryTables.ToListAsync();
            return res;
        }

        public async Task UpdateEnquiry(Enquiry enquiry)
        {
            try
            {
                var res = await _connect.EnquiryTables.FirstOrDefaultAsync(x => x.EnqId == enquiry.EnqId);
                if (res == null)
                {
                    throw new KeyNotFoundException("not found");
                }
                res.EnqId = enquiry.EnqId;
                res.Name = enquiry.Name;
                res.Status = enquiry.Status;
                res.Email = enquiry.Email;
                res.DOB = enquiry.DOB;
                res.CreatedBy = enquiry.CreatedBy;
                res.ModifiedBy = enquiry.ModifiedBy;
                res.CreatedOn = enquiry.CreatedOn;
                res.ModifiedOn = enquiry.ModifiedOn;
                res.Gender = enquiry.Gender;
                res.PhoneNo = enquiry.PhoneNo;
                res.EnquiyFor = enquiry.EnquiyFor;
                _connect.EnquiryTables.Update(enquiry);
                await _connect.SaveChangesAsync();

            }
           catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }
    }
}
