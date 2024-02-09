using AllModels.DTO;
using AllModels.Model;
using AutoMapper;
using BusinessLayer_08012024.IServices;
using MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatriMonialAppProjectSecond_08012024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictMasterService _districtMaster;
        private readonly IMapper _mapp;
        public DistrictsController(IDistrictMasterService districtMasterService, IMapper mapper)
        {
            this._districtMaster = districtMasterService;
            this._mapp = mapper;
        }
        [HttpGet]
        [Route("GetAllDistrictMasterData")]
        public async Task<IActionResult> GetAllDistrictMasterData()
        {
            try
            {
               var res=await _districtMaster.GetAllDistrictMasterData();
                var result = _mapp.Map<List<DistrictMaster>>(res);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddedNewDataOfDistrictMastder")]
        public async Task<IActionResult> AddedNewDataOfDistrictMastder(DistrictMasterDto districtMasterDto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var res = _mapp.Map<DistrictMaster>(districtMasterDto);
                    await _districtMaster.AddNewDistrictMasterData(res);
                    return Ok("Added SuccessFully");
                }
                else
                {
                    throw new BadRequestException("not found");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteDataById")]
        public async Task<IActionResult> DeleteDataById(Guid id)
        {
            var res=await _districtMaster.DeletedDataById(id);
            return Ok(res);

        }
        [HttpPut("UpdateDataOfDistrict")]
        public async Task<IActionResult> UpdateDataOfDistrict(DistrictMasterDto districtMasterDto)
        {
            var res = _mapp.Map<DistrictMaster>(districtMasterDto);
            var result=await _districtMaster.UpdateDataOfDistrict(res);
            return Ok(result);
        }
        [HttpGet("GetByIdData")]
        public async Task<IActionResult> GetByIdData(Guid id)
        {
            var res=await _districtMaster.GetNewDistrictMasterById(id);
            var result=_mapp.Map<DistrictMasterDto>(res);
            return Ok(result);
        }
    }
}
