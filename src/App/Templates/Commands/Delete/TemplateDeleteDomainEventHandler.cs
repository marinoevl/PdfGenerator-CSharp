using MediatR;
using PdfGenerator.Domain.DomainEvents;

namespace App.Templates.Commands.Delete;

internal sealed class TemplateDeleteDomainEventHandler
    : INotificationHandler<TemplateDeleteDomainEvent>
{
    public Task Handle(TemplateDeleteDomainEvent notification, CancellationToken cancellationToken)
    {
        //Sent Email
        
        //Do Some External stuff
        
        //Do Something else
        return Task.FromResult("");
    }
}