using CapitalInternshipProgram.Containers;
using CapitalInternshipProgram.DTO;
using CapitalInternshipProgram.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalInternshipProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppTempController : ControllerBase
    {
        private readonly ApplicationTempContainer<AppTemp> _repository;
        public AppTempController(ApplicationTempContainer<AppTemp> repository)
        {
            _repository = repository;
        }

        [HttpGet("{ProgramId}")]
        public async Task<IActionResult> GetTempByProgamId(string ProgramId)
        {
            
            var item = await _repository.GetItemAsync(ProgramId);
            
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound("This Program Has No  Temp");
        }
        [HttpPut]
        public async Task<IActionResult> Update(string ProgramId, [FromBody] AppTempToAddDto newTempDto)
        {
            
            AppTemp item = await _repository.GetItemAsync(ProgramId) as AppTemp;
            if (item != null)
            {
                AppTemp newAppTemp = new AppTemp(newTempDto);
                newAppTemp.ProgrameId = item.ProgrameId;
                newAppTemp.Id = item.Id;
                var respose = await _repository.UpdateTemp(item.Id.ToString(), newAppTemp);
                if (respose != null)
                {
                    return Ok("Template Updated");
                }
                return BadRequest("Somthing Went Wrong");
            }
            else
            {
                return BadRequest("Temp Not Found ...Please Enter Correct Program ID ");
            }
            
        }
    }
}
