using App.Templates.Create;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.UnitTests.Create;

public class CreateTemplateCommandHandlerUnitTests
{
    private readonly Mock<IGenericRepository<Template, Guid>> _mockTemplateRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CreateTemplateCommandHandler _handler;

    public CreateTemplateCommandHandlerUnitTests()
    {
        _mockTemplateRepository = new Mock<IGenericRepository<Template, Guid>>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateTemplateCommandHandler(_mockUnitOfWork.Object, _mockTemplateRepository.Object);
    }

    [Fact]
    public void HandlerCreateTemplate_WhenTemplateContentIsEmpty()
    {
        
    }
    
    [Fact]
    public void HandlerCreateTemplate_When_TemplateNameExists()
    {
        
    }
}