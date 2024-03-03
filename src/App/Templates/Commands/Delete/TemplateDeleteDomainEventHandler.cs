using MediatR;
using Microsoft.Extensions.Logging;
using PdfGenerator.Domain.DomainEvents;

namespace App.Templates.Commands.Delete;

internal sealed class TemplateDeleteDomainEventHandler(ILogger<TemplateDeleteDomainEventHandler> logger)
    : INotificationHandler<TemplateDeleteDomainEvent>
{
    public Task Handle(TemplateDeleteDomainEvent notification, CancellationToken cancellationToken)
    {
        //Sent Email
        
        //Do Some External stuff
        
        //Do Something else
        logger.LogInformation($"Template Deleted: {notification.Id}");
        return Task.FromResult("");
    }
}