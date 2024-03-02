using MediatR;
using PdfGenerator.Domain.Shared;
using PdfGenerator.Domain.Templates;

namespace App.Templates.GetById;

public sealed class GetByIdTemplateQueryHandler( 
    IGenericRepository<Template, Guid> templateRepository)
    : IRequestHandler<GetByIdTemplateQuery, Template?>
{
    public async Task<Template?> Handle(GetByIdTemplateQuery query, CancellationToken cancellationToken)
    {
        return await templateRepository.GetAsync(m =>m.Id == query.TemplateId, cancellationToken); 
    }
}