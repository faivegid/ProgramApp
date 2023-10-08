using Moq;
using ProgramApp.Domain.ApplicationStages;
using ProgramApp.Domain.ApplicationTemplates;
using ProgramApp.Domain.Programs;
using ProgramApp.Shared.ApplicationStages;

namespace ProgramApp.Test.AppServices
{
    [TestClass]
    public class ProgramAppServiceTests : BaseTest
    {
        private IProgramAppService _appService;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            _appService = GetService<IProgramAppService>();
        }

        [TestMethod]
        public async Task CreateProgram_ShouldCreateProgramAndReturnDto()
        {
            // Arrange
            var createRto = fixture.Build<ProgramCreateRto>().Create();
            unitOfWorkMock.Setup(uow => uow.Programs.Insert(It.IsAny<Program>()));

            // Act
            var result = await _appService.CreateProgram(createRto);

            // Assert
            unitOfWorkMock.Verify(uow => uow.Programs.Insert(It.IsAny<Program>()), Times.Once);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetProgramList_ShouldReturnPaginatedList()
        {
            // Arrange
            var request = new PaginationRequest { Page = 1, ContentPerPage = 10 };
            var programs = fixture.Build<Program>().CreateMany(20).ToList();
            var expectedResult = programs.Skip((request.Page - 1) * request.ContentPerPage).Take(request.ContentPerPage).ToList();
            unitOfWorkMock.Setup(uow => uow.Programs.Count()).ReturnsAsync(programs.Count());
            unitOfWorkMock.Setup(uow => uow.Programs.GetList(request.Page, request.ContentPerPage)).ReturnsAsync(expectedResult);

            // Act
            var result = await _appService.GetProgramList(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(programs.Count(), result.TotalCount);
            Assert.AreEqual(request.ContentPerPage, result.Data.Count());
        }

        [TestMethod]
        public async Task GetProgram_WhenProgramExists_ShouldReturnProgramDto()
        {
            // Arrange
            var programId = Guid.NewGuid();
            var program = fixture.Build<Program>().With(x => x.Id, programId).Create();
            unitOfWorkMock.Setup(uow => uow.Programs.Get(programId)).ReturnsAsync(program);

            // Act
            var result = await _appService.GetProgram(programId);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UpdateProgram_WhenProgramExists_ShouldReturnProgramDto()
        {
            // Arrange
            var programId = Guid.NewGuid();
            var updateRto = fixture.Build<ProgramUpdateRto>().With(x => x.Title, "updated title").Create();
            var program = fixture.Build<Program>().With(x => x.Title, "old stage name").With(x => x.Id, programId).Create();

            unitOfWorkMock.Setup(uow => uow.Programs.Get(programId)).ReturnsAsync(program);

            // Act
            var result = await _appService.UpdateProgram(programId, updateRto);

            // Assert
            unitOfWorkMock.Verify(uow => uow.Programs.Update(It.IsAny<Program>()), Times.Once);
            unitOfWorkMock.Verify(uow => uow.Programs.Insert(It.IsAny<Program>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Title, program.Title);
        }

        [TestMethod]
        public async Task Preview_WhenProgramExists_ShouldReturnProgramPreview()
        {
            // Arrange
            var programId = Guid.NewGuid();
            var program = fixture.Build<Program>().With(x => x.Id, programId).Create();

            unitOfWorkMock.Setup(uow => uow.Programs.GetById(programId)).ReturnsAsync(program);

            // Act
            var result = await _appService.Preview(programId);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
