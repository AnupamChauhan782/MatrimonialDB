using AllModels.DTO;
using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IUserService
    {
        Task AddUser(UserModelDTO dto);
        Task<string> Login(LoginModelDTO loginDto);

        

    }
}
