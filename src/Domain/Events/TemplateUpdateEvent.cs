using PdfGenerator.Domain.Shared;

namespace PdfGenerator.Domain.Events;

public record TemplateUpdateEvent(Guid Id) : IDomainEvent;
