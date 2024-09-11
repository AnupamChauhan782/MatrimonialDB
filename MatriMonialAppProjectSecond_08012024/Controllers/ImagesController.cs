
using AllModels.Model;
using AutoMapper;
using BusinessLayer_08012024.IServices;
using DataAccessLayer_08012024.DbConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriMonialAppProjectSecond_08012024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IFileService _fileService;
       
        
        public ImagesController(IFileService fileService)
        {
            this._fileService = fileService;
            
          
        }
      
        [HttpPost]
        [Route("AddImage")]
        public async Task<IActionResult> AddImage(IFormFile[] file,[  FromForm] Guid proId)
        {

            await _fileService.AddFileUpLoad(file, proId);
            return Ok("Upload Successfully");
          
        }

    }
}
