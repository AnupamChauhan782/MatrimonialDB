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
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _service;
        private readonly IMapper _mapper;
        public QualificationController(IQualificationService service,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        [HttpGet("GetQualificationData")]
        public async Task<IActionResult> GetQualificationData()
        {
            var res = await _service.GetAllQualification();
            var result=_mapper.Map<List<QualificationMasterDto>>(res);
            return Ok(result);
        }
        [HttpPost("AddedQualificationData")]
        public async Task<IActionResult> AddedQualificationData(QualificationMasterDto dto)
        {
            var res = _mapper.Map<QualificationMaster>(dto);
            await _service.AddQualification(res);
            return Ok("Added New Qualification");
        }
        [HttpDelete("DeleteQualificationData")]
        public async Task<IActionResult> DeleteQualificationData(Guid id)
        {
            var res = await _service.DeleteQyalication(id);
            return Ok(res);

        }
        [HttpPut("UpdatedQualificationData")]
        public async Task<IActionResult> UpdatedQualificationData(QualificationMasterDto dto)
        {
            var res=_mapper.Map<QualificationMaster>(dto);
            var result=await _service.UpdateQualication(res);
            return Ok(result);
        }
    }
}
