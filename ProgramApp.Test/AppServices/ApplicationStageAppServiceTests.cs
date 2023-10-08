using ProgramApp.AppService.ApplicationStages;
using ProgramApp.Domain.ApplicationStages;
using ProgramApp.Shared.ApplicationStages;

namespace ProgramApp.Test.AppServices
{
    [TestClass]
    public class ApplicationStageAppServiceTests : BaseTest
    {
        private IApplicationStageAppService _appService;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _appService = GetService<IApplicationStageAppService>();
        }

        [TestMethod]
        public async Task CreateStage_WithExistingStageId_ShouldUpdateStage()
        {
            // Arrange
            var createRto = fixture.Build<ApplicationStageCreateRto>()
                    .With(x => x.StageName, "updated stage name").With(x => x.StageId, Guid.NewGuid()).Create();
            var existingStage = fixture.Build<ApplicationStage>()
                    .With(x => x.StageName, "old stage name").With(x => x.Id, createRto.StageId).Create();

            unitOfWorkMock.Setup(uow => uow.ApplicationStages.GetById(createRto.StageId)).ReturnsAsync(existingStage);

            // Act
            var result = await _appService.CreateStage(createRto);

            // Assert
            unitOfWorkMock.Verify(uow => uow.ApplicationStages.Update(existingStage), Times.Once);
            unitOfWorkMock.Verify(uow => uow.ApplicationStages.Insert(It.IsAny<ApplicationStage>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StageName, createRto.StageName);
        }

        [TestMethod]
        public async Task CreateStage_WithNonExistingStageId_ShouldInsertNewStage()
        {
            // Arrange
            Guid? stageId = null;
            var createRto = fixture.Build<ApplicationStageCreateRto>().With(x => x.StageId, stageId).Create();
            unitOfWorkMock.Setup(uow => uow.ApplicationStages.GetById(It.IsAny<Guid>())).ReturnsAsync((ApplicationStage)null);

            // Act
            var result = await _appService.CreateStage(createRto);

            // Assert
            unitOfWorkMock.Verify(uow => uow.ApplicationStages.Update(It.IsAny<ApplicationStage>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.ApplicationStages.Insert(It.IsAny<ApplicationStage>()), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetStages_ShouldReturnListOfApplicationStageDto()
        {
            // Arrange
            var programId = Guid.NewGuid();
            var stages = fixture.Build<ApplicationStage>()
                    .With(x => x.ProgramId, programId).CreateMany(10).ToList();

            unitOfWorkMock.Setup(uow => uow.ApplicationStages.GetByProgram(programId)).ReturnsAsync(stages);

            // Act
            var result = await _appService.GetStages(programId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(stages.Count, result.Count);
        }

        [TestMethod]
        public async Task GetStageById_ShouldReturnApplicationStageDto()
        {
            // Arrange
            var stageId = Guid.NewGuid();
            var stage = fixture.Build<ApplicationStage>()
                    .With(x => x.Id, stageId).Create();
            unitOfWorkMock.Setup(uow => uow.ApplicationStages.GetById(stageId)).ReturnsAsync(stage);

            // Act
            var result = await _appService.GetStageById(stageId);

            // Assert
            Assert.IsNotNull(result);
        }
    }

}
