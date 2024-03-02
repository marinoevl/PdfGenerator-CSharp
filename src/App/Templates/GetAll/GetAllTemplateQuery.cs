using MediatR;
using PdfGenerator.Domain.Templates;

namespace App.Templates.GetAll;

public record GetAllTemplateQuery() : IRequest<List<Template>>;
