using ProgramApp.AppService.ApplicationTemplates;
using ProgramApp.Domain.ApplicationTemplates;
using ProgramApp.Shared.ApplicationTemplate;

namespace ProgramApp.Test.AppServices
{
    [TestClass]
    public class ApplicationTemplateAppServiceTests: BaseTest
    {
        private IApplicationTemplateAppService _appService;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _appService= GetService<IApplicationTemplateAppService>();
        }

        [TestMethod]
        public async Task CreateTemplate_WhenTemplateDoesNotExist_ShouldCreateNewTemplate()
        {
            // Arrange
            var programId = Guid.NewGuid();
            var createRto = fixture.Build<ApplicationCreaeteRto>().With(x => x.ProgramId, programId).Create();

            unitOfWorkMock.Setup(uow => uow.ApplicationTemplates.GetByProgram(programId))
                .ReturnsAsync((ApplicationTemplate)null);

            // Act
            var result = await _appService.CreateTemplate(createRto);

            // Assert
            unitOfWorkMock.Verify(uow => uow.ApplicationTemplates.Insert(It.IsAny<ApplicationTemplate>()), Times.Once);
            unitOfWorkMock.Verify(uow => uow.ApplicationTemplates.Update(It.IsAny<ApplicationTemplate>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateTemplate_WhenTemplateExist_ShouldUpdateTemplate()
        {
            // Arrange
            var programId = Guid.NewGuid();
            var createRto = fixture.Build<ApplicationCreaeteRto>().With(x => x.ProgramId, programId).Create();
            var template = fixture.Build<ApplicationTemplate>().With(x => x.ProgramId, programId).Create();

            unitOfWorkMock.Setup(uow => uow.ApplicationTemplates.GetByProgram(programId))
                .ReturnsAsync(template);

            // Act
            var result = await _appService.CreateTemplate(createRto);

            // Assert
            unitOfWorkMock.Verify(uow => uow.ApplicationTemplates.Insert(It.IsAny<ApplicationTemplate>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.ApplicationTemplates.Update(It.IsAny<ApplicationTemplate>()), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTemplate_WhenTemplateExists_ShouldReturnTemplateDto()
        {
            // Arrange
            var programId = Guid.NewGuid();
            var template = fixture.Build<ApplicationTemplate>().With(x => x.ProgramId, programId).Create();

            unitOfWorkMock.Setup(uow => uow.ApplicationTemplates.GetByProgram(programId))
                .ReturnsAsync(template);

            // Act
            var result = await _appService.GetTemplate(programId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTempalteById_WhenTemplateExists_ShouldReturnTemplateDto()
        {
            // Arrange
            var templateId = Guid.NewGuid();
            var template = fixture.Build<ApplicationTemplate>().With(x => x.Id, templateId).Create();

            unitOfWorkMock.Setup(uow => uow.ApplicationTemplates.GetById(templateId))
                .ReturnsAsync(template);

            // Act
            var result = await _appService.GetTempalteById(templateId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTempalteById_WhenTemplateDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var templateId = Guid.NewGuid();

            unitOfWorkMock.Setup(uow => uow.ApplicationTemplates.GetById(templateId))
                .ReturnsAsync((ApplicationTemplate)null);

            // Act
            var result = await _appService.GetTempalteById(templateId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
