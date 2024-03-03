using MediatR;

namespace App.Templates.Commands.Create;

public record CreateTemplateCommand(string Name, string Content): IRequest<Unit>;