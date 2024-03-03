using FluentValidation;

namespace App.Templates.Commands.Update;

public class UpdateTemplateCommandValidator: AbstractValidator<UpdateTemplateCommand>
{
    public UpdateTemplateCommandValidator()
    {
        RuleFor(r => r.TemplateId)
            .NotEmpty()
            .WithName("Template Id");

        RuleFor(r => r.Content)
            .NotEmpty();
    }
}