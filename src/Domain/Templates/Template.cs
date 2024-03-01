using PdfGenerator.Domain.Shared;

namespace PdfGenerator.Domain.Templates;

public sealed class Template : BaseDomain, IAuditableDomain
{
    public Template(Guid id, string name, string content, bool deleteFlag = false)
    {
        Id = id;
        Name = name;
        Content = content;
        DeleteFlag = deleteFlag;
    }
    
    public Template()
    {
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
    public string? LastModifierBy { get; set; }
    public DateTime? LastModifierDate { get; set; }
    public bool DeleteFlag { get; private set; }


    public void MarkDeleted()
    {
        DeleteFlag = true;
    }

    public void Update(string content)
    {
        Content = content;
    }
    
}