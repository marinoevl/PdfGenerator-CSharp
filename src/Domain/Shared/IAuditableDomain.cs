namespace PdfGenerator.Domain.Shared;

public interface IAuditableDomain
{
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } 
    public string? LastModifierBy { get; set; }
    public DateTime? LastModifierDate { get; set; }
}