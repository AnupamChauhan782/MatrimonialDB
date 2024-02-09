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
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionMasterService _professionMasterService;
        private readonly IMapper _mapper;
        public ProfessionController(IProfessionMasterService professionMasterService,IMapper mapper)
        {
            this._professionMasterService = professionMasterService;
            this._mapper = mapper;
        }
        [HttpGet("GetProfession")]
        public async Task<IActionResult> GetProfession()
        {
            var res = await _professionMasterService.GetProfessionMaster();
            var result=_mapper.Map<List<ProfessionMasterDto>>(res);
            return Ok(result);
        }
        [HttpPost("AddedNewProfession")]
        public async Task<IActionResult> AddedNewProfession(ProfessionMasterDto professionMasterDto)
        {
            var res = _mapper.Map<ProfessionMaster>(professionMasterDto);
            await _professionMasterService.AddNewProfession(res);
            return Ok("Added SuccessFully");
        }
        [HttpDelete("DeleteProfessionById")]

        public async Task<IActionResult> DeleteProfessionById(Guid id)
        {
             await _professionMasterService.DeleteProfession(id);
            return Ok("Delete Success");
        }

        [HttpPut("UpdateDataOfProfession")]
        public async Task<IActionResult> UpdateDataOfProfession(ProfessionMasterDto professionMasterDto)
        {
            var res = _mapper.Map<ProfessionMaster>(professionMasterDto);
            var result=await _professionMasterService.UpdateProfessionMaster(res);
            return Ok(result);
        }
        [HttpGet("GetByIdToProfessionMaster")]
        public async Task<IActionResult> GetByIdToProfessionMaster(Guid id)
        {
            var res = await _professionMasterService.GetByIdProfessionMaster(id);
            var result = _mapper.Map<ProfessionMasterDto>(res);
            return Ok(result);
        }
    }
}
