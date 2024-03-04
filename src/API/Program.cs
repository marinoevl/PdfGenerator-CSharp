using API;
using API.Extensions;
using Infrastructure;
using App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddWebServices()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseExceptionHandler(options => { });


app.Run();