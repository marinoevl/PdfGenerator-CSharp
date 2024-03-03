using FluentValidation;

namespace App.Templates.Queries.GetById;

public class GetByIdTemplateQueryValidator: AbstractValidator<GetByIdTemplateQuery>
{
    public GetByIdTemplateQueryValidator()
    {
        RuleFor(r => r.TemplateId)
            .NotEmpty()
            .WithName("Template Id");
    }
}