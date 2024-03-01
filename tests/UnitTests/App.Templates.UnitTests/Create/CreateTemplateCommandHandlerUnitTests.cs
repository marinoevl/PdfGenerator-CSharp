using System.Linq.Expressions;
using App.Shared.Exceptions;
using App.Templates.Create;
using LinqKit;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.UnitTests.Create;

public class CreateTemplateCommandHandlerUnitTests
{
    private readonly Mock<IGenericRepository<Template, Guid>> _mockTemplateRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private CreateTemplateCommandHandler _handler;

    public CreateTemplateCommandHandlerUnitTests()
    {
        _mockTemplateRepository = new Mock<IGenericRepository<Template, Guid>>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
    }

    [Fact]
    public async Task HandlerCreateTemplate_WhenTemplateNameExists_ShouldRaiseValidationException()
    {
        //Arrange
        var template = new Template(Guid.NewGuid(), "template-1", "<httml></html>");
        var command = new CreateTemplateCommand("template-1", "<httml></html>");
        var cancelationToken = new CancellationToken();
        _mockTemplateRepository
            .Setup(m => m.GetAsync(It.IsAny<Expression<Func<Template, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(template);
        _handler = new CreateTemplateCommandHandler(_mockUnitOfWork.Object, _mockTemplateRepository.Object);


        //Act
        var ex = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, default));

        //Assert
        Assert.NotNull(ex);
        Assert.IsType<ValidationException>(ex);
    }

    [Fact]
    public async Task HandlerCreateTemplate_WhenItsCorrect_ShouldCreateRecord()
    {
        //Arrange
        var template = new Template(Guid.NewGuid(), "template-1", "<httml></html>");
        var command = new CreateTemplateCommand("template-2", "<httml></html>");
        var cancelationToken = new CancellationToken();
        _mockTemplateRepository
            .Setup(m => m.GetAsync(It.Is<Expression<Func<Template, bool>>>(m => m.Name == template.Name),
                It.IsAny<CancellationToken>())).ReturnsAsync(template);
        _handler = new CreateTemplateCommandHandler(_mockUnitOfWork.Object, _mockTemplateRepository.Object);

        //Act
        var result = await _handler.Handle(command, cancelationToken);

        //Assert
        _mockTemplateRepository.Verify(r => r.AddAsync(It.IsAny<Template>(), cancelationToken), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(cancelationToken), Times.Once);
    }
}