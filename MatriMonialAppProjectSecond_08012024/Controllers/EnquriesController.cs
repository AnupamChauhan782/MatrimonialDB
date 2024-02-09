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
    public class EnquriesController : ControllerBase
    {
        private readonly IEnquiryService _service;
        private readonly IMapper _mapper;
        public EnquriesController(IEnquiryService service,IMapper mapper)
        {
            this. _mapper = mapper;
            this._service = service;
        }
        [HttpGet("GetDataOfEnquiry")]
        public async Task<IActionResult> GetDataOfEnquiry()
        {
            var res = await _service.GetEnquiryList();
            var result=_mapper.Map<List<EnquiryDto>>(res);
            return Ok(result);
        }
        [HttpPost("AddedNewData")]
        public async Task<IActionResult> AddedNewData(EnquiryDto dto)
        {
            var res=_mapper.Map<Enquiry>(dto);
            await _service.AddNewEnquiry(res);
            return Ok("Added SuccessFully");
        }
        [HttpDelete("DeleteDataById")]
        public async Task<IActionResult> DeleteDataById(Guid id)
        {
            var res = await _service.DeleteEnquiry(id);
            return Ok(res);
        }
        [HttpPut("UpdateDataOfEnquiry")]
        public async Task<IActionResult> UpdateDataOfEnquiry(EnquiryDto dto)
        {
            try
            {
                var res = _mapper.Map<Enquiry>(dto);
                 await _service.UpdateEnquiry(res);
                return Ok("Updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
