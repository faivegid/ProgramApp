using Microsoft.AspNetCore.Mvc;
using ProgramApp.AppService.ApplicationTemplates;
using ProgramApp.Shared.ApplicationTemplate;
using ProgramApp.Shared.Responses;

namespace ProgramApp.Controllers
{
    [Route("api/template")]
    [ApiController]
    public class ApplicationTemplateController : ControllerBase
    {
        private readonly IApplicationTemplateAppService _appService;

        public ApplicationTemplateController(IApplicationTemplateAppService appService)
        {
            _appService = appService;
        }

        [HttpPut, Route("")]
        public async Task<ApiResponse<ApplicationTemplateDto>> Create(ApplicationCreaeteRto creaeteRto)
        {
            var data = await _appService.CreateTemplate(creaeteRto);
            return ApiResponse.Success(data);
        }

        [HttpGet, Route("{templateId}")]
        public async Task<ApiResponse<ApplicationTemplateDto>> Get([FromRoute]Guid templateId)
        {
            var data = await _appService.GetTempalteById(templateId);
            return ApiResponse.Success(data);
        }

        [HttpGet, Route("")]
        public async Task<ApiResponse<ApplicationTemplateDto>> GetByProgram([FromQuery] Guid programId)
        {
            var data = await _appService.GetTemplate(programId);
            return ApiResponse.Success(data);
        }
    }
}
