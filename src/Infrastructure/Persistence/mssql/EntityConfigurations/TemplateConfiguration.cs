using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PdfGenerator.Domain.Templates;

namespace Infrastructure.Persistence.mssql.EntityConfigurations;

public class TemplateConfiguration: IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name).HasMaxLength(50);
        builder.Property(m => m.Content);
        builder.Property(m => m.CreatedBy).HasMaxLength(50);
        builder.Property(m => m.LastModifierBy).HasMaxLength(50);
    }
}