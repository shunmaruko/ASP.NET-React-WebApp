using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.OpenApi.Models;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repository;
using Backend.Infrastructure.SeedData;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<UserDTO>, UserRepository>();
builder.Services.AddScoped<IRepository<TodoItemDTO>, TodoItemRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddDbContext<TodoItemContext>(opt => opt.UseInMemoryDatabase(nameof(TodoItem)));
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase(nameof(User)));
builder.Services.AddDbContext<SchoolContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// To ignore System.Text.Json.JsonException, see https://learn.microsoft.com/ja-jp/ef/core/querying/related-data/serialization
builder.Services.AddMvc()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

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

Utils.CreateSchoolRelatedDbIfNotExists(app);
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
public class Utils
{
    public static void CreateSchoolRelatedDbIfNotExists(IHost app)
    { 
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Program>>();
            try
            {
                var context = services.GetRequiredService<SchoolContext>();
                DbInitializer.Initialize(context);
                logger.LogInformation("Succeed db connection.");

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}