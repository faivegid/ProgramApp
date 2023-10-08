using AutoMapper;
using ProgramApp.Domain.EfCore.UnitOfWorks;
using ProgramApp.Domain.Programs;
using ProgramApp.Shared.Base;
using ProgramApp.Shared.Exceptions;
using ProgramApp.Shared.Helpers;
using ProgramApp.Shared.Programs;
using ProgramApp.Shared.Responses;

namespace ProgramApp.AppService.Programs
{
    public class ProgramAppService : IProgramAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgramAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProgramDto> CreateProgram(ProgramCreateRto createRto)
        {
            var program = new Program();
            UpdateHelper.UpdateModelProperties(program, createRto);

            _unitOfWork.Programs.Insert(program);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProgramDto>(program);
        }

        public async Task<PaginationData<ProgramDto>> GetProgramList(PaginationRequest request)
        {
            var count = await _unitOfWork.Programs.Count();
            var programs =  await _unitOfWork.Programs.GetList(request.Page, request.ContentPerPage);

            var programDtos = _mapper.Map<List<ProgramDto>>(programs);
            return new PaginationData<ProgramDto>(request.Page, count, programDtos);
        }

        public async Task<ProgramDto> GetProgram(Guid programId)
        {
            var program = await _unitOfWork.Programs.Get(programId);
            return _mapper.Map<ProgramDto>(program);
        }

        public async Task<ProgramDto> UpdateProgram(Guid programId, ProgramUpdateRto updateRto)
        {
            var program = await _unitOfWork.Programs.Get(programId);
            
            if(program == null)
            {
                throw new ProgramAppException("Program not found", System.Net.HttpStatusCode.NotFound);
            }

            UpdateHelper.UpdateModelProperties(program, updateRto);

            _unitOfWork.Programs.Update(program);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProgramDto>(program);
        }
    }
}
