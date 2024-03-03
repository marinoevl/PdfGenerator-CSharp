using MediatR;

namespace App.Templates.Commands.Delete;

public record DeleteTemplateCommand(Guid TemplateId): IRequest<Unit>;