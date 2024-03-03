using App.Shared.Exceptions;
using MediatR;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.Commands.Delete;

internal sealed class DeleteTemplateCommandHandler(
    IGenericRepository<Template, Guid> templateRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteTemplateCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTemplateCommand command, CancellationToken cancellationToken)
    {
        var template = await templateRepository.GetAsync(m => m.Id == command.TemplateId, cancellationToken);

        if (template == null) throw new NotFoundException(nameof(command), command);
        
        template.MarkDeleted();
        
        templateRepository.Update(template);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}