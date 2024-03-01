using FluentValidation;

namespace App.Templates.Create;

public class CreateTemplateCommandValidator: AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Content)
            .NotEmpty();
    }
    
}