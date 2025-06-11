using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApi.DataAccess.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventRegistrationApi.Api;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventRegistrationApiDbContext>
{
    public EventRegistrationApiDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets(typeof(Program).Assembly)
            .Build();
        var builder = new DbContextOptionsBuilder<EventRegistrationApiDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        builder.UseSqlServer(connectionString);
        return new EventRegistrationApiDbContext(builder.Options);
    }
}
