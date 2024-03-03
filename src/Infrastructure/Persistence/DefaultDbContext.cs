using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PdfGenerator.Domain.Shared;

namespace Infrastructure.Persistence;

public class DefaultDbContext(DbContextOptions<DefaultDbContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}