using MediatR;

namespace App.Templates.Queries.Exports;

public record GeneratePdfQuery(
    string template_name,
    Dictionary<string, object> context
) : IRequest<string>;