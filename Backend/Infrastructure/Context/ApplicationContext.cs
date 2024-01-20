using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using Backend.Models;

namespace Backend.Infrastructure.Context
{
    public class ApplicationContext: ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
        {
        }
    }
}
