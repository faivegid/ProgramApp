using ProgramApp.Shared.Base;
using ProgramApp.Shared.Programs;
using ProgramApp.Shared.Responses;

namespace ProgramApp.AppService.Programs
{
    public interface IProgramAppService
    {
        Task<ProgramDto> CreateProgram(ProgramCreateRto createRto);
        Task<ProgramDto> GetProgram(Guid programId);
        Task<PaginationData<ProgramDto>> GetProgramList(PaginationRequest request);
        Task<ProgramDto> UpdateProgram(Guid programId, ProgramUpdateRto updateRto);
    }
}