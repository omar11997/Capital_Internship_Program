using CapitalInternshipProgram.Containers;
using CapitalInternshipProgram.DTO;
using CapitalInternshipProgram.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalInternshipProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly WorkFlowContainer<WorkFlow> _repository;
        public WorkFlowController(WorkFlowContainer<WorkFlow> repository)
        {
            _repository = repository;
        }
        [HttpGet("{ProgramId}")]
        public async Task<IActionResult> GetByProgramId(string ProgramId )
        {
            var workFlow = await _repository.GetItemAsync(ProgramId);
            if (workFlow != null)
            {
                return Ok(workFlow);
            }
            return NotFound("This Program Has No WorkFlows");

        }
        [HttpPut]
        public async Task<IActionResult> Update(string ProgramId, [FromBody] WorkFlowToAddDTO newWorkFlowDto)
        {

            WorkFlow item = await _repository.GetItemAsync(ProgramId);
            if (item != null)
            {
                WorkFlow newWorkFlow = new WorkFlow(newWorkFlowDto);
                newWorkFlow.ProgramId = item.ProgramId;
                newWorkFlow.Id = item.Id;
                var respose = await _repository.UpdateWorkFlow(newWorkFlow.Id.ToString(), newWorkFlow);
                if (respose != null)
                {
                    return Ok("Work Flow Updated");
                }
                return BadRequest("Somthing Went Wrong");
            }

            return BadRequest("Somthing Went Wrong... Enter The Right Program ID");
        }
    }
}
