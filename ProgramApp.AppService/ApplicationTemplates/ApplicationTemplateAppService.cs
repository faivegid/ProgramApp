using AutoMapper;
using Microsoft.Extensions.Configuration;
using ProgramApp.Domain.ApplicationTemplates;
using ProgramApp.Domain.EfCore.UnitOfWorks;
using ProgramApp.Domain.Programs;
using ProgramApp.Shared.ApplicationTemplate;
using Profile = ProgramApp.Shared.ApplicationTemplate.Profile;
using QuestionGroup = ProgramApp.Shared.ApplicationTemplate.QuestionGroup;

namespace ProgramApp.AppService.ApplicationTemplates
{
    public class ApplicationTemplateAppService : IApplicationTemplateAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public ApplicationTemplateAppService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        private List<QuestionGroup> GetQuestionGroups(Profile profile)
        {
            var list = new List<QuestionGroup>();
            if (profile.IsEducationSelected)
            {
                var education = _config.GetSection("EducationTemplate").Get<List<QuestionTemplate>>();
                list.Add(new QuestionGroup { IsMandatory = profile.IsEducationManadatory, Name = "Education", Questions = education });
            }
            if (profile.IsExperienceSelected)
            {
                var exp = _config.GetSection("WoekExperienceTemplate").Get<List<QuestionTemplate>>();
                list.Add(new QuestionGroup { IsMandatory = profile.IsExperienceMandatory, Name = "Work Experience", Questions = exp });
            }

            if (profile.IsResumeSelected)
            {
                var resume = _config.GetSection("WoekExperienceTemplate").Get<List<QuestionTemplate>>();
                list.Add(new QuestionGroup { IsMandatory = profile.IsResumeMandatory, Name = "Resume Upload", Questions = resume });
            }

            if (profile.AdditionalQuestions.Count > 0)
            {
                list.Add(new QuestionGroup { IsMandatory = true, Name = "Adiitional Questions", Questions = profile.AdditionalQuestions });
            }

            return list;
        }

        public async Task<ApplicationTemplateDto> CreateTemplate(ApplicationCreaeteRto creaeteRto)
        {
            var template = await _unitOfWork.ApplicationTemplates.GetByProgram(creaeteRto.ProgramId);
            if (template == null)
            {
                template = new ApplicationTemplate()
                {
                    ProgramId = creaeteRto.ProgramId,
                    PersonalInfo = creaeteRto.PersonalInfo,
                    AdditionalQuestions = creaeteRto.AdditionalQuestions,
                    Profile = GetQuestionGroups(creaeteRto.Profile)
                };

                _unitOfWork.ApplicationTemplates.Insert(template);
            }
            else
            {
                var profile = GetQuestionGroups(creaeteRto.Profile);
                template.AdditionalQuestions = creaeteRto.AdditionalQuestions;
                template.Profile = profile;
                template.PersonalInfo = creaeteRto.PersonalInfo;

                _unitOfWork.ApplicationTemplates.Update(template);
            }

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ApplicationTemplateDto>(template);
        }

        public async Task<ApplicationTemplateDto> GetTemplate(Guid programId)
        {
            var template = await _unitOfWork.ApplicationTemplates.GetByProgram(programId);
            return _mapper.Map<ApplicationTemplateDto>(template);
        }

        public async Task<ApplicationTemplateDto> GetTempalteById(Guid templateId)
        {
            var template = await _unitOfWork.ApplicationTemplates.GetById(templateId);
            return _mapper.Map<ApplicationTemplateDto>(template);
        }
    }
}
