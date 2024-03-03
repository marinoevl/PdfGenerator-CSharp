using MediatR;

namespace App.Templates.Commands.Update;

public record UpdateTemplateCommand(Guid TemplateId, string Content) : IRequest<Unit>;