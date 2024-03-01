using MediatR;

namespace App.Templates.Delete;

public record DeleteTemplateCommand(Guid TemplateId): IRequest<Unit>;