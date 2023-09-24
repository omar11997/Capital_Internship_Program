using CapitalInternshipProgram.Containers;
using CapitalInternshipProgram.DTO;
using CapitalInternshipProgram.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalInternshipProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly ProgramContainer<MyProgram> programRepo;
        private readonly ApplicationTempContainer<AppTemp> appTempRepo;
        public PreviewController(ProgramContainer<MyProgram> programRepository, ApplicationTempContainer<AppTemp> appTempRepository) 
        { 

            programRepo = programRepository;
            appTempRepo = appTempRepository;    
        }

        [HttpGet]
        public async Task<IActionResult> GetPreview(string programId)
        {
            
            MyProgram program = await programRepo.GetItemAsync(programId);
            if (program != null)
            {
                AppTemp appTemp = await appTempRepo.GetItemAsync(programId);
                if (appTemp != null)
                {
                    PreviewDTO previewDTO = new PreviewDTO(program,appTemp);
                    return Ok(previewDTO);
                }
                PreviewDTO previewWithoutCoverImage = new PreviewDTO(program);
                return Ok(previewWithoutCoverImage);

            }
            return BadRequest("Program Not Fount ... Enter Correct Program ID");

        }
    }
}
