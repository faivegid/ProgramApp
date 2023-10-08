using Microsoft.AspNetCore.Mvc;
using ProgramApp.AppService.Programs;
using ProgramApp.Shared.Base;
using ProgramApp.Shared.Programs;
using ProgramApp.Shared.Responses;

namespace ProgramApp.Controllers
{
    [Route("api/program")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramAppService _programAppService;

        public ProgramController(IProgramAppService programAppService)
        {
            _programAppService = programAppService;
        }

        [HttpGet, Route("/{programId}")]
        public async Task<ApiResponse<ProgramDto>> GetProgram([FromRoute] Guid programId)
        {
            var data = await _programAppService.GetProgram(programId);
            return ApiResponse.Success(data);
        }

        [HttpGet, Route("")]
        public async Task<ApiResponse<PaginationData<ProgramDto>>> GetPrograms([FromQuery] PaginationRequest pagination)
        {
            var data = await _programAppService.GetProgramList(pagination);
            return ApiResponse.Success(data);
        }

        [HttpPost, Route("")]
        public async Task<ApiResponse<ProgramDto>> CreateProgram([FromBody] ProgramCreateRto createRto)
        {
            var data = await _programAppService.CreateProgram(createRto);
            return ApiResponse.Success(data);
        }

        [HttpPatch, Route("{programId}")]
        public async Task<ApiResponse<ProgramDto>> CreateProgram([FromRoute] Guid programId, [FromBody] ProgramUpdateRto updateRto)
        {
            var data = await _programAppService.UpdateProgram(programId, updateRto);
            return ApiResponse.Success(data);
        }

        public async Task<ApiResponse<ProgramPreview>> Preview([FromRoute] Guid programId)
        {

        }
    }
}
