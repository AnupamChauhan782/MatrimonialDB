using AllModels.DTO;
using AllModels.Model;
using AutoMapper;
using BusinessLayer_08012024.IServices;
using DataAccessLayer_08012024.DbConnection;
using MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatriMonialAppProjectSecond_08012024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryMasterService _service;
        private readonly IMapper _mapper;
        public CountriesController(ICountryMasterService service,IMapper mapper)
        {
            this._service = service;
            this. _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllDataOfCountryMaster")]
        public async Task<IActionResult> GetAllDataOfCountryMaster()
        {
            try
            {
                var res = await _service.GetAllDataOfCountryMaster();
                var result=_mapper.Map<List<CountryMasterDto>>(res);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }


        }
        [HttpPost]
        [Route("AddedNewDataOfCountry")]
        public async Task<IActionResult> AddedNewDataOfCountry(CountryMasterDto countryMasterDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = _mapper.Map<CountryMaster>(countryMasterDto);
                    await _service.AddNewCountryMasterData(res);
                    return Ok("Added SuccessFully");
                }
                else
                {
                    throw new NotFoundException("not found");
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteDataOfCountryMasterById")]
        public async Task<IActionResult> DeleteDataOfCountryMasterById(Guid id)
        {
            var res=await _service.DeletedDataOfCountryMaster(id);
            return Ok(res);
        }
        [HttpPut]
        [Route("UpadateDataOfCountryMaster")]
        public async Task<IActionResult> UpadateDataOfCountryMaster(CountryMasterDto countryMasterDto)
        {
            var res=_mapper.Map<CountryMaster>(countryMasterDto);
            await _service.UpDateDataOfCountryMaster(res);
            return Ok("Updated SuccessFully");
        }
    }
}
