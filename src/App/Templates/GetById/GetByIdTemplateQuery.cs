using MediatR;
using PdfGenerator.Domain.Templates;

namespace App.Templates.GetById;

public record GetByIdTemplateQuery(Guid TemplateId) : IRequest<Template?>;
