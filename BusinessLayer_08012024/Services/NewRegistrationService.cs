using AllModels.DTO;
using AllModels.Model;
using AutoMapper;
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
    public class NewRegistrationService : INewRegistrationService
    {
        private readonly Connection _connect;
     
        public NewRegistrationService(Connection connection)
        {
            this._connect = connection;
            
        }

        public async Task AddNewRegistrationData(NewRegistrationModel newRegistration)
        {
            if(newRegistration == null)
            {
                throw new BadRequestException("you are doing add data of same id it is impossible");
            }
            else
            {
                await _connect.NewRegistarTabb.AddAsync(newRegistration);
                    await _connect.SaveChangesAsync();
            }
        }

        public async Task<NewRegistrationModel> DeleteNewRegistrationData(Guid id)
        {
            var res=await _connect.NewRegistarTabb.FirstOrDefaultAsync(x=>x.ProfileID==id);
            if(res==null)
            {
                throw new KeyNotFoundException("Key not found");
            }
            _connect.NewRegistarTabb.Remove(res);
            await _connect.SaveChangesAsync();
            return res;
        }

        public async Task<List<NewRegistrationModel>> NewRegistrationData()
        {
            var res = await _connect.NewRegistarTabb.ToListAsync();
            return res;
        }

        public async Task<NewRegistrationModel> UpdateNewRegistration(NewRegistrationModel newRegistration)
        {
            var res=await _connect.NewRegistarTabb.FirstOrDefaultAsync(x=>x.ProfileID == newRegistration.ProfileID);
            if(res == null)
            {
                throw new KeyNotFoundException("Key not found");
            }
            res.ProfileID=newRegistration.ProfileID;
            res.Religion  = newRegistration.Religion;
            res.Location = newRegistration.Location;
            res.HomeLocation = newRegistration.HomeLocation;
            res.Complexion = newRegistration.Complexion;
            res.CreatedBy = newRegistration.CreatedBy;
            res.CreatedOn = newRegistration.CreatedOn;
            res.ModifiedBy = newRegistration.ModifiedBy;
            res.ModifiedOn = newRegistration.ModifiedOn;
            res.Height = newRegistration.Height;
            res.ImageId = newRegistration.ImageId;
            res.Age = newRegistration.Age;
             _connect.NewRegistarTabb.Update(res);
            await _connect.SaveChangesAsync();
            return res;

        }
    }
}
