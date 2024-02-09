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
    public class EducationController : ControllerBase
    {
        private readonly IEducationMasterService _masterService;
        private readonly IMapper _mapper;
        public EducationController(IEducationMasterService educationMasterService,IMapper mapper)
        {
            this._masterService = educationMasterService;
            this._mapper = mapper;
        }
        [HttpGet]
        [Route("GetEducationMasterData")]
        public async Task<IActionResult> GetEducationMasterData()
        {
            var res = await _masterService.GetAllDataOfEducation();
            var result = _mapper.Map<List<EducationMasterDto>>(res);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddedDataOfEducationMaster")]
        public async Task<IActionResult> AddedDataOfEducationMaster(EducationMasterDto dto)
        {
            var res=_mapper.Map<EducationMaster>(dto);  
            await _masterService.AddNewEducationData(res);
            return Ok("Added Success");
        }
        [HttpDelete]
        [Route("DeleteDataOfEducationMaster")]
        public async Task<IActionResult> DeleteDataOfEducationMaster(Guid id)
        {
            await _masterService.DeleteById(id);
            return Ok("Deleted Success");
        }
        [HttpGet]
        [Route("GetByIdOfEducationMasterData")]
        public async Task<IActionResult> GetByIdOfEducationMasterData(Guid id)
        {
            var res = await _masterService.GetById(id);
            var result=_mapper.Map<EducationMasterDto>(res);
            return Ok(result);
        }

    }
}
