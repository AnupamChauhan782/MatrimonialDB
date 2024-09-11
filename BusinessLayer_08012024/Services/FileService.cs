using AllModels.DTO;
using AllModels.Model;
using AutoMapper;
using BusinessLayer_08012024.IServices;
using DataAccessLayer_08012024.DbConnection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.Services
{
    public class FileService : IFileService
    {
        private readonly Connection _connect;
        private readonly IMapper _mapper;
        public FileService(Connection connection, IMapper mapper)
        {
            this._connect = connection;
            this._mapper = mapper;
        }
        public async Task AddFileUpLoad(IFormFile[] file, Guid profileId)
        {
            FileUploadDTO fileUploadDTO = new FileUploadDTO();
            if (file != null && file.Length > 0)
            {

                foreach (var files in file)
                {
                    fileUploadDTO.ProfileID = profileId;    
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
                    var filePath = Path.Combine("Assets/Image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files.CopyToAsync(stream);
                    }
                    if (fileUploadDTO.FileUpLoadOne == null)
                    {
                        fileUploadDTO.FileUpLoadOne = fileName;
                    }
                    else if (fileUploadDTO.FileUploadTwo == null)
                    {
                        fileUploadDTO.FileUploadTwo = fileName;
                    }
                    else
                    {
                        fileUploadDTO.FileUploadThree = fileName;
                    }
                }
                var map=_mapper.Map<FileUploadMODEL>(fileUploadDTO);    
                await _connect.ImageUploadTabb.AddRangeAsync(map);
                await _connect.SaveChangesAsync();


            }
            
        }
    }
}
