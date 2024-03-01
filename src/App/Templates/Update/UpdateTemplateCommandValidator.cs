using FluentValidation;

namespace App.Templates.Update;

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