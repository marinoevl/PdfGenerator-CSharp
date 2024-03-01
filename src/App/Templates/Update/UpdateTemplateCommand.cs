using MediatR;

namespace App.Templates.Update;

public record UpdateTemplateCommand(Guid TemplateId, string Content) : IRequest<Unit>;