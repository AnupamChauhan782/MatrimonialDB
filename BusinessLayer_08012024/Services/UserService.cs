using AllModels.DTO;
using AllModels.Model;
using AutoMapper;
using BusinessLayer_08012024.IServices;
using DataAccessLayer_08012024.DbConnection;
using MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using UnauthorizedAccessException = System.UnauthorizedAccessException;

namespace BusinessLayer_08012024.Services
{
    public class UserService : IUserService
    {
        private readonly Connection _connection;
        private readonly IMapper _mapper;
        public UserService(Connection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }
        public async Task AddUser(UserModelDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    throw new NotFoundException("Not found");
                }
                else
                {
                    var res = _mapper.Map<UserModel>(dto);
                    await _connection.UserTabb.AddAsync(res);
                    await _connection.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

     

        public async Task<string> Login(LoginModelDTO loginDto)
        {
            try
            {
                if (await _connection.UserTabb.AnyAsync(x => x.UserName != loginDto.UserName)) 
                {
                    throw new BadRequestException("EMAIL_NOT_FOUND");
                }
                else if(await _connection.UserTabb.AnyAsync(x=>x.Password !=loginDto. Password))
                {
                    throw new BadRequestException(" INVALID_PASSWORD");
                }
                var result=await _connection.UserTabb.FirstOrDefaultAsync(x=>x.UserName == loginDto. UserName&&x.Password==loginDto.Password);
                if(result == null)
                {
                    throw new UnauthorizedAccessException("USER_DISABLED");
                }
                var token= GenerateToken(result).ToString();
                return token;


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        private string GenerateToken(UserModel model)
        {
            var tokenHandler=new JwtSecurityTokenHandler();
            var sequirtyKey = Encoding.UTF32.GetBytes("JwtToken:SecretKey");
            var TokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(sequirtyKey), SecurityAlgorithms.HmacSha256)
            };
            var token=tokenHandler.CreateToken(TokenDiscriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
