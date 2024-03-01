using MediatR;

namespace Application.Templates.Create;

public record CreateTemplateCommand(string Name, string Content): IRequest<Unit>;