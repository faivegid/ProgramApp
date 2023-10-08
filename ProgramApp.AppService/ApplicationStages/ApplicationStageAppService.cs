using AutoMapper;
using ProgramApp.Domain.ApplicationStages;
using ProgramApp.Domain.EfCore.UnitOfWorks;
using ProgramApp.Shared.ApplicationStages;
using ProgramApp.Shared.Helpers;

namespace ProgramApp.AppService.ApplicationStages
{
    public class ApplicationStageAppService : IApplicationStageAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationStageAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApplicationStageDto> CreateStage(ApplicationStageCreateRto createRto)
        {
            ApplicationStage stage = createRto.StageId != null ? await _unitOfWork.ApplicationStages.GetById(createRto.StageId) : null;
           
            if (stage != null) _unitOfWork.ApplicationStages.Update(stage);
            else
            {
                stage = new();
                _unitOfWork.ApplicationStages.Insert(stage);
            };

            UpdateHelper.UpdateModelProperties(stage, createRto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ApplicationStageDto>(stage);
        }

        public async Task<List<ApplicationStageDto>> GetStages(Guid programId)
        {
            var stages = await _unitOfWork.ApplicationStages.GetByProgram(programId);
            return _mapper.Map<List<ApplicationStageDto>>(stages);
        }

        public async Task<ApplicationStageDto> GetStageById(Guid stageId)
        {
            var stage = await _unitOfWork.ApplicationStages.GetById(stageId);
            return _mapper.Map<ApplicationStageDto>(stage);
        }
    }
}
