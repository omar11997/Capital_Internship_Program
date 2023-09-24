using CapitalInternshipProgram.Containers;
using CapitalInternshipProgram.DTO;
using CapitalInternshipProgram.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
namespace CapitalInternshipProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly ProgramContainer<MyProgram> _repository;
        //private readonly Container _container;
        public ProgramController(ProgramContainer<MyProgram> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.GetAllPrograms();
            return Ok(data);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProgramById(string Id)
        {
            
            var item = await _repository.GetItemAsync(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProgramToAddDTO programDto)
        {
            if (ModelState.IsValid == true) {
                MyProgram newProgram = new MyProgram(programDto);
                 var respose = await _repository.AddProgram(newProgram);
                if(respose != null)
                {
                    return Ok("Program is  added  Successfully");
                }
                return BadRequest("Somthing Went Wrong");
                
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(string programId,[FromBody] ProgramToAddDTO programDto)
        {
            if(ModelState.IsValid == true)
            {
                MyProgram newProgram = new MyProgram(programDto);
                newProgram.Id = new Guid(programId);
                var respose = await _repository.updateProgram(programId, newProgram);
                if (respose != null)
                {
                    return Ok("Program Updated");
                }
                return BadRequest("Somthing Went Wrong");
            }
            return BadRequest("Some Inforamtions is Required");
            
        }
    }
}
