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
    public class StatesMasController : ControllerBase
    {
        private readonly IStateMasterService _stateMasterService;
        private readonly IMapper _mapp;
        public StatesMasController(IStateMasterService stateMasterService,IMapper mapp)
        {
            this._stateMasterService = stateMasterService;
            this._mapp = mapp;
        }
        [HttpGet]
        [Route("GetAllDataOfStateMaster")]
        public async Task<IActionResult> GetAllDataOfStateMaster()
        {
            try
            {
                var res = await _stateMasterService.GetAllStateMastersData();
                var result = _mapp.Map<List<StateMasterDto>>(res);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetStateById")]
        public async Task<IActionResult> GetStateById(Guid id)
        {
            try
            {
                var res = await _stateMasterService.GetNewStateById(id);
                var result = _mapp.Map<List<StateMasterDto>>(res);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddedNewStateMasterData")]
        public async Task<IActionResult> AddedNewStateMasterData(StateMasterDto stateMasterDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = _mapp.Map<StateMaster>(stateMasterDto);
                    await _stateMasterService.AddNewStateMasterData(res);
                    return Ok("Added Success");
                }
                else
                {
                    throw new Exception("not found");
                }
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteDataOfStateMaster")]
        public async Task<IActionResult> DeleteDataOfStateMaster(Guid id)
        {
            var res = await _stateMasterService.DeleteNewStateMasterData(id);
            return Ok(res);

        }
        [HttpPut("UpdateDataOfStateMaster")]
        public async Task<IActionResult> UpdateDataOfStateMaster(StateMasterDto stateMasterDto)
        {
            var res = _mapp.Map<StateMaster>(stateMasterDto);
            await _stateMasterService.UpdateNewStateMasterData(res);
            return Ok("Updated SuccessFully");
        }
       
    }
}
