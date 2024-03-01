using FluentValidation;

namespace App.Templates.Delete;

public class DeleteTemplateCommandValidator: AbstractValidator<DeleteTemplateCommand>
{
    public DeleteTemplateCommandValidator()
    {
        RuleFor(r => r.TemplateId)
            .NotEmpty()
            .WithName("Template Id");
    }
    
}