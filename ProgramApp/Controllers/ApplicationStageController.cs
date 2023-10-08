using Microsoft.AspNetCore.Mvc;
using ProgramApp.AppService.ApplicationStages;
using ProgramApp.Domain.ApplicationStages;
using ProgramApp.Shared.ApplicationStages;
using ProgramApp.Shared.Responses;

namespace ProgramApp.Controllers
{
    [Route("api/workflow")]
    [ApiController]
    public class ApplicationStageController : ControllerBase
    {
        private readonly IApplicationStageAppService _appService;

        public ApplicationStageController(IApplicationStageAppService appService)
        {
            _appService = appService;
        }

        [HttpPut, Route("")]
        public async Task<ApiResponse<ApplicationStageDto>> CreateStage([FromBody]ApplicationStageCreateRto createRto)
        {
            var data = await _appService.CreateStage(createRto);
            return ApiResponse.Success(data);
        }

        [HttpGet, Route("{stageId}")]
        public async Task<ApiResponse<ApplicationStageDto>> GetStageById([FromRoute]Guid stageId)
        {
            var data = await _appService.GetStageById(stageId);
            return ApiResponse.Success(data);
        }

        [HttpGet, Route("")]
        public async Task<ApiResponse<ApplicationStageDto>> GetStage([FromQuery] Guid programId)
        {
            var data = await _appService.GetStageById(programId);
            return ApiResponse.Success(data);
        }
    }
}
