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

        public async Task<NewRegistrationModel> AddNewRegistrationData(NewRegistrationModel newRegistration)
        {
            var res = await _connect.NewRegistarTabbColl.AddAsync(newRegistration);
            if (newRegistration == null)
            {
                throw new BadRequestException("you are doing add data of same id it is impossible");
            }
            await   _connect.NewRegistarTabbColl.AddAsync(newRegistration);
            await _connect.SaveChangesAsync();
            return newRegistration;
            
            
        }

        public async Task<NewRegistrationModel> DeleteNewRegistrationData(Guid id)
        {
            var res=await _connect.NewRegistarTabbColl.FirstOrDefaultAsync(x=>x.ProfileID==id);
            if(res==null)
            {
                throw new KeyNotFoundException("Key not found");
            }
            _connect.NewRegistarTabbColl.Remove(res);
            await _connect.SaveChangesAsync();
            return res;
        }

        public async Task<object> GetAllNewREgistration()
        {
            var query = from NewRegistrationModel in _connect.NewRegistarTabbColl
                        join SubCasteMaster in _connect.SubCasteMasterTabb on NewRegistrationModel.SubCasteId equals SubCasteMaster.SubCasteId
                        join GotraMaster in _connect.GotraMasterTabb on NewRegistrationModel.GotraId equals GotraMaster.GotraId
                        join CountryMaster in _connect.CountryMasterTabb on NewRegistrationModel.CountryId equals CountryMaster.CountryId
                        join StateMaster in _connect.StateMasterTabb on NewRegistrationModel.StateId equals StateMaster.StateId
                        join DistrictMaster in _connect.DistrictMasterTabb on NewRegistrationModel.DistrictId equals DistrictMaster.DistrictId
                        join ProfessionMaster in _connect.ProfessionTab on NewRegistrationModel.ProfessionId equals ProfessionMaster.ProfessionId
                        join QualificationMaster in _connect.QualificationTabb on NewRegistrationModel.QualificationId equals QualificationMaster.QualificationId
                        join image in _connect.ImageUploadTabb on NewRegistrationModel.ProfileID equals image.ProfileID
                        select new
                        {
                            Location = NewRegistrationModel.location,
                            Religion = NewRegistrationModel.Religion,
                            Age = NewRegistrationModel.Age,
                            MaritalStatus = NewRegistrationModel.MaritalStatus,
                            Height = NewRegistrationModel.Height,
                            Caste = NewRegistrationModel.Caste,
                            Complexion = NewRegistrationModel.Complexion,
                            SubCaste = SubCasteMaster.SubCasteName,
                            HomeLocation = NewRegistrationModel.HomeLocation,
                            Gotra = GotraMaster.GortaName,
                            District = DistrictMaster.DistrictName,
                            Qualification = QualificationMaster.QualificationName,
                            State = StateMaster.StateName,
                            Profession = ProfessionMaster.ProfessionName,
                            Country = CountryMaster.CountryName,

                           image1=image.FileUpLoadOne, image2=image.FileUploadTwo,image3=image.FileUploadThree
                          //  FileName = NewRegistrationModel.fileUpload.Select(x => (new { x.FileUpLoadOne, x.FileUploadTwo, x.FileUploadThree })).ToList()



                        };
            return query;

                       
        }

        public async Task<List<NewRegistrationModel>> NewRegistrationData()
        {
            var res = await _connect.NewRegistarTabbColl. Include(x=>x.fileUpload).ToListAsync();
            return res;
        }

        public async Task<NewRegistrationModel> UpdateNewRegistration(NewRegistrationModel newRegistration)
        {
            var res=await _connect.NewRegistarTabbColl.FirstOrDefaultAsync(x=>x.ProfileID == newRegistration.ProfileID);
            if(res == null)
            {
                throw new KeyNotFoundException("Key not found");
            }
            res.ProfileID=newRegistration.ProfileID;
           
            res.Religion  = newRegistration.Religion;
            res.location = newRegistration.location;
            res.MaritalStatus = newRegistration.MaritalStatus;
            res.HomeLocation = newRegistration.HomeLocation;
            res.Age = newRegistration.Age;
            res.Caste=newRegistration.Caste;
            res.Complexion = newRegistration.Complexion;
            res.CreatedBy = newRegistration.CreatedBy;
            res.CreatedOn = newRegistration.CreatedOn;
            res.ModifiedBy = newRegistration.ModifiedBy;
            res.ModifiedOn = newRegistration.ModifiedOn;
            res.Height = newRegistration.Height;
            res.CountryId = newRegistration.CountryId;
            res.SubCasteId = newRegistration.SubCasteId;
            res.ProfessionId = newRegistration.ProfessionId;
            res.GotraId = newRegistration.GotraId;
            res.StateId = newRegistration.StateId;
            res.DistrictId = newRegistration.DistrictId;
            res.EnqId = newRegistration.EnqId;
           
            res.QualificationId = newRegistration.QualificationId;
            
            res.Age = newRegistration.Age;
             _connect.NewRegistarTabbColl.Update(res);
            await _connect.SaveChangesAsync();
            return res;

        }
    }
}
