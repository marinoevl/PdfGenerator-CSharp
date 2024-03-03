using PdfGenerator.Domain.Shared;

namespace PdfGenerator.Domain.DomainEvents;

public sealed record TemplateDeleteDomainEvent(Guid Id) : IDomainEvent;
