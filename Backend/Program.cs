using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Repository;
using Backend.Infrastructure.SeedData;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container. Authorize all controller by default.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
});
// Add Repository for DI to Controller
builder.Services.AddScoped<IRepository<UserDTO>, UserRepository>();
builder.Services.AddScoped<IRepository<TodoItemDTO>, TodoItemRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
// DI for DbContext
builder.Services.AddDbContext<TodoItemContext>(opt => opt.UseInMemoryDatabase(nameof(TodoItem)));
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase(nameof(User)));
builder.Services.AddDbContext<SchoolContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));

// Authentication + Authorization
// Add Authentication + default UI TODO is it really necessary?
builder.Services.AddDefaultIdentity<ApplicationUser>(
        options => options.SignIn.RequireConfirmedAccount = true // if true 
    )
    .AddEntityFrameworkStores<ApplicationContext>(); // determine where user informations are stored.
// Add default cokkie authentication + add api authorization
builder.Services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationContext>();   
// Add jwt validation to authentication
builder.Services.AddAuthentication().AddIdentityServerJwt();

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

builder.Services.AddHsts(options =>
{
    options.Preload = true; // assure to use http at first request
    options.IncludeSubDomains = true; 
    options.MaxAge = TimeSpan.FromDays(365);
});

var app = builder.Build();

Utils.CreateSchoolRelatedDbIfNotExists(app);

// Configure the HTTP request pipeline.
// For the order of middleware you can see
// https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else
{
    app.UseExceptionHandler("/Error");
    //  To protect from man-in-the-middle (MITM), HSTS with preload enforce browser to 
    // access by HTTPS.
    // The default HSTS value is 365 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //https://developer.mozilla.org/ja/docs/Web/HTTP/Headers/Strict-Transport-Security
    app.UseHsts();
}
// Https redirectoin is added just in case HSTS is not supported in client browser
app.UseHttpsRedirection();

// Add AuthenticationMiddleware to request pipeline 
// which must be called before UseAuthorization
app.UseIdentityServer();
// Add AuthorizationMiddleware to request pipeline
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