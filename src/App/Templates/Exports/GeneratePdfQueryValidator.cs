using FluentValidation;

namespace App.Templates.Exports;

public class GeneratePdfQueryValidator: AbstractValidator<GeneratePdfQuery>
{
    public GeneratePdfQueryValidator()
    {
        RuleFor(r => r.template_name)
            .NotEmpty()
            .WithName("template name");
    }
}