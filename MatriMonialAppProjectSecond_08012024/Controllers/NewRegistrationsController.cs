using AllModels.DTO;
using AllModels.Model;
using AutoMapper;
using BusinessLayer_08012024.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatriMonialAppProjectSecond_08012024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRegistrationsController : ControllerBase
    {
        private readonly INewRegistrationService _registrationService;
        private readonly IMapper _mapper;
        public NewRegistrationsController(IMapper mapper,INewRegistrationService newRegistrationService)
        {
            this._registrationService = newRegistrationService;
            this._mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllDataOfNewRegistration")]
        public async Task<IActionResult> GetAllDataOfNewRegistration()
        {
            var res=await _registrationService.NewRegistrationData();
            var map = _mapper.Map<List<NewRegistrationDTO>>(res);
            return Ok(map);
        }

        [HttpPost]
        [Route("AddNewRegisatration")]
        public async Task<IActionResult> AddNewRegisatration(NewRegistrationDTO newRegistrationDTO)
        {
            var res = _mapper.Map<NewRegistrationModel>(newRegistrationDTO);
            await _registrationService.AddNewRegistrationData(res);
            return Ok("Added Successfully");
        }

        [HttpDelete]
        [Route("DeleteDataofNewRegistration")]
       
        public async Task<IActionResult> DeleteDataofNewRegistration(Guid id)
        {
            var res = await _registrationService.DeleteNewRegistrationData(id);
            return Ok(res);
        }

        [HttpPut]
        [Route("UpdateDataOfNewRegistration")]
        public async Task<IActionResult> UpdateDataOfNewRegistration(NewRegistrationDTO dto)
        {
            var map = _mapper.Map<NewRegistrationModel>(dto);
            var res=await _registrationService.UpdateNewRegistration(map);
            return Ok(res);
        }
    }
}
