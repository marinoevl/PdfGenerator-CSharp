using MediatR;
using Microsoft.EntityFrameworkCore;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.Queries.GetAll;

internal sealed class GetAllTemplateQueryHandler( 
    IGenericRepository<Template, Guid> templateRepository)
    : IRequestHandler<GetAllTemplateQuery, List<Template>>
{
    public async Task<List<Template>> Handle(GetAllTemplateQuery request, CancellationToken cancellationToken)
    {
        var templates = templateRepository.GetAll();
        return await templates.ToListAsync(cancellationToken);
    }
}