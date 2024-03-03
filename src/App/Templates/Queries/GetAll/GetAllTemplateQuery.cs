using MediatR;
using PdfGenerator.Domain.Templates;

namespace App.Templates.Queries.GetAll;

public record GetAllTemplateQuery() : IRequest<List<Template>>;
