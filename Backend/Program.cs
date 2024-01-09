using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.OpenApi.Models;
using Backend.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoItemContext>(opt => opt.UseInMemoryDatabase(nameof(TodoItem)));
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase(nameof(User)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ASP.NET-React-Web API",
        Description = "Backend API for ASP.NET-React-Web",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "shunmaruko",
            Url = new Uri("https://github.com/shunmaruko")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/license/mit/")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
