using MediatR;

namespace PdfGenerator.Domain.Shared;

public record DomainEvent(Guid Id): INotification;