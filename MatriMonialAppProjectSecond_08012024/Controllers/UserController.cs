using AllModels.DTO;
using AllModels.Model;
using BusinessLayer_08012024.IServices;
using DataAccessLayer_08012024.DbConnection;
using MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriMonialAppProjectSecond_08012024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Connection _connect;
        private readonly IUserService _service;
        public UserController(Connection connection,IUserService service)
        {
            this ._connect = connection;
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _connect.UserTabb.ToListAsync();
            return Ok(res);
        }

        [HttpPost("AddUserData")]
        public async Task<IActionResult> AddUserData(UserModelDTO dto)
        {
            try
            {
                 await _service.AddUser(dto);
                return Ok("Added SuccessFully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddLoginData")]
        public async Task<IActionResult> AddLoginData(LoginModelDTO modelDTO)
        {
            try
            {
              var token=  await _service.Login(modelDTO);
                return Ok("Token is this"+"-"+token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteData")]
        public async Task<IActionResult> DeleteData(Guid id)
        {
            var res=await _connect.UserTabb.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                return BadRequest("Not found");
            }
             _connect.UserTabb.Remove(res);
            await _connect.SaveChangesAsync();
            return Ok(res);

        }



        // Revoken is use For Removing token entry

    }
}
