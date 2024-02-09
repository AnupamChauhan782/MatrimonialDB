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
    public class GotrasController : ControllerBase
    {
        private readonly IGotraMasterService _gotraService;
        private readonly IMapper _mapper;
        public GotrasController(IGotraMasterService gotraMasterService,IMapper mapper)
        {
             this._gotraService = gotraMasterService;
            this._mapper = mapper;
        }
        [HttpGet]
        [Route("GetGotraMasterData")]
        public async Task<IActionResult> GetGotraMasterData()
        {
            var res=await _gotraService.GetGotraMasterData();
            var result = _mapper.Map<List<GotraMaster>>(res);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddedNewDataOfGotraMaster")]
        public async Task<IActionResult> AddedNewDataOfGotraMaster(GotraMasterDto gotraMasterDto)
        {
            var res=_mapper.Map<GotraMaster>(gotraMasterDto);
            await _gotraService.AddNewGotraMasterData(res);
            return Ok("Added SuccessFully");
        }
        [HttpDelete("DeleteDataById")]
        public  async Task<IActionResult> DeleteDataById(Guid id)
        {
            var res=await _gotraService.DeleteData(id);
            return Ok(res);
        }
        [HttpPut("UpdateDataOfGotraMaster")]
        public async Task<IActionResult> UpdateDataOfGotraMaster(GotraMasterDto dto)
        {
            var res = _mapper.Map<GotraMaster>(dto);
            var result = await _gotraService.UpadateData(res);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res=await _gotraService.GetGotraMasterById(id);
            var result=_mapper.Map<GotraMasterDto>(res);
            return Ok(result);
        }
    }
}
