using MediatR;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;
using Microsoft.EntityFrameworkCore;

namespace App.Templates.GetAll;

public sealed class GetAllTemplateQueryHandler( 
    IGenericRepository<Template, Guid> templateRepository)
    : IRequestHandler<GetAllTemplateQuery, List<Template>>
{
    public async Task<List<Template>> Handle(GetAllTemplateQuery request, CancellationToken cancellationToken)
    {
        var templates = templateRepository.GetAll();
        return await templates.ToListAsync(cancellationToken);
    }
}