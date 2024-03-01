using MediatR;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace Application.Templates.Create;

public sealed class CreateTemplateCommandHandler: IRequestHandler<CreateTemplateCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Template, Guid> _templateRepository;
    private const string user = "DefaultUser";

    public CreateTemplateCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Template, Guid> templateRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _templateRepository = templateRepository ?? throw new ArgumentNullException(nameof(templateRepository));
    }

    public async Task<Unit> Handle(CreateTemplateCommand command, CancellationToken cancellationToken)
    {
        var exitingEntity = await _templateRepository.GetAsync(m => m.Name == command.Name);

        if (exitingEntity is null) throw new InvalidOperationException(nameof(command));

        var template = new Template
        (
            Guid.NewGuid(),
            command.Name,
            command.Content,
            user,
            DateTime.Now
        );

        await _templateRepository.AddAsync(template);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;

    }
}