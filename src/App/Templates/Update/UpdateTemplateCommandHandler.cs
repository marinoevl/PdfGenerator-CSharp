using App.Shared.Exceptions;
using MediatR;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.Update;

public class UpdateTemplateCommandHandler(
    IGenericRepository<Template, Guid> templateRepository,
    IUnitOfWork unitOfWork): IRequestHandler<UpdateTemplateCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTemplateCommand command, CancellationToken cancellationToken)
    {
        var template = await templateRepository.GetAsync(m => m.Id == command.TemplateId, cancellationToken);

        if (template == null) throw new NotFoundException(nameof(command), command);
        
        template.Update(command.Content);
        
        templateRepository.Update(template);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}