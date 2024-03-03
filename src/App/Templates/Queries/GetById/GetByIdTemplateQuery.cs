using MediatR;
using PdfGenerator.Domain.Templates;

namespace App.Templates.Queries.GetById;

public record GetByIdTemplateQuery(Guid TemplateId) : IRequest<Template?>;
