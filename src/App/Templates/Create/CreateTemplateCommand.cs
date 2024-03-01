using MediatR;

namespace App.Templates.Create;

public record CreateTemplateCommand(string Name, string Content): IRequest<Unit>;