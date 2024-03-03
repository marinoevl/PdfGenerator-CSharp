using App.Shared.Exceptions;
using MediatR;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.Commands.Create;

public sealed class CreateTemplateCommandHandler: IRequestHandler<CreateTemplateCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Template, Guid> _templateRepository;

    public CreateTemplateCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Template, Guid> templateRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _templateRepository = templateRepository ?? throw new ArgumentNullException(nameof(templateRepository));
    }

    public async Task<Unit> Handle(CreateTemplateCommand command, CancellationToken cancellationToken)
    {
        var exitingEntity = await _templateRepository.GetAsync(m => m.Name == command.Name, cancellationToken);

        if (exitingEntity is not null) throw new ValidationException("Template duplicated", nameof(command.Name));

        var template = new Template
        (
            Guid.NewGuid(),
            command.Name,
            command.Content
        );

        await _templateRepository.AddAsync(template, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}