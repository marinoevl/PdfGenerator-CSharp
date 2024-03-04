using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PdfGenerator.Domain.Shared;



namespace Infrastructure.Persistence.mongo;

public class MongoDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}