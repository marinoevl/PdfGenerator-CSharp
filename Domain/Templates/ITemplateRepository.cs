namespace PdfGenerator.Domain.Templates;

public interface ITemplateRepository
{
    Task<Template?> GetByIdAsync(Guid id);
    Task Add(Template template);
}