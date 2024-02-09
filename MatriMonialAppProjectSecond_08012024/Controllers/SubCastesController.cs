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
    public class SubCastesController : ControllerBase
    {
        private readonly ISubCasteMasterService _service;
        private readonly IMapper _mapp;
        public SubCastesController(ISubCasteMasterService casteMasterService,IMapper mapper)
        {
             this._service = casteMasterService;
            this._mapp = mapper;
        }
        [HttpGet]
        [Route("GetAllDataOfCasteMaster")]
        public async Task<IActionResult> GetAllDataOfCasteMaster()
        {

            var res=await _service.GetSubCasteMasterData();
            var result=_mapp.Map<List<SubCasteMaster>>(res);    
            return Ok(result);
        }
        [HttpPost]
        [Route("AddedNewCatseMasterData")]
        public async Task<IActionResult> AddedNewCatseMasterData(SubCasteMasterDto casteMasterDto)
        {
            var res = _mapp.Map<SubCasteMaster>(casteMasterDto);
            await _service.AddNewSubCasteMasterData(res);
            return Ok(res);
        }
        [HttpDelete("DeleteDataById")]
        public async Task<IActionResult> DeleteDataById(Guid id)
        {
             await _service.DeleteSubCasteMasterData(id);
            return Ok();

        }
        [HttpPut("UpdateData")]
        public async Task<IActionResult> UpdateData(SubCasteMasterDto casteMasterDto)
        {
            var res = _mapp.Map<SubCasteMaster>(casteMasterDto);
            await _service.UpdateSubCasteMasterData(res);
            return Ok("Updated SuccessFuuly");
        }
    }
}
