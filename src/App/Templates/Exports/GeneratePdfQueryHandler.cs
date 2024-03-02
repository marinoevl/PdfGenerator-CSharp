using App.Shared.Extensions;
using MediatR;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.Exports;

public class GeneratePdfQueryHandler: IRequestHandler<GeneratePdfQuery, string>
{
    private readonly IGenericRepository<Template, Guid> _templateRepository;

    public GeneratePdfQueryHandler(IGenericRepository<Template, Guid> templateRepository)
    {
        _templateRepository = templateRepository;
    }

    public async Task<string> Handle(GeneratePdfQuery query, CancellationToken cancellationToken)
    {
        var content = await GetTemplateContent(query.template_name, cancellationToken);

        if (string.IsNullOrEmpty(content)) throw new InvalidOperationException(nameof(query));

        var bytes = content
            .GetMergeTemplateWithData(query.context)
            .ConvertHtmlStringToPdf();

        return Convert.ToBase64String(bytes);
    }

    private async Task<string> GetTemplateContent(string name, CancellationToken cancellationToken)
    {
        var template = await _templateRepository.GetAsync(m => m.Name == name, cancellationToken);
        return template?.Content != null ? template.Content.FromBase64ToString() : string.Empty;
    }
}