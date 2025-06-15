using EventRegistrationApi.Application.Config;
using EventRegistrationApi.DataAccess.Repositories;
using EventRegistrationApi.Domain.Abstractions.Repositories;

using appServiceAbstractions = EventRegistrationApi.Application.Abstractions.Services;
using appQueryServiceAbstractions = EventRegistrationApi.Application.Abstractions.Queries;
using AppServices = EventRegistrationApi.Application.Services;
using AppQueryServices = EventRegistrationApi.Application.Queries;
using EventRegistrationApiApi.DataAccess.Repositories;

namespace EventRegistrationApi.Api.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddMappings(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(
            typeof(EventRegistrationApi.DataAccess.MappingProfiles.ParticipantMappingProfile).Assembly);

        return serviceCollection;
    }


    public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IParticipantRepository, ParticipantRepository>();
        serviceCollection.AddScoped<IEventRepository, EventRepository>();

        return serviceCollection;
    }

    public static IServiceCollection AddConfigurations(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<DapperConfig>(configuration.GetSection(DapperConfig.ConfigurationSection));
        return serviceCollection;
    }


    public static IServiceCollection AddAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<appServiceAbstractions.IParticipantService, AppServices.ParticipantService>();
        serviceCollection.AddScoped<appServiceAbstractions.IEventService, AppServices.EventService>();
        
        serviceCollection.AddScoped<appQueryServiceAbstractions.IParticipantQueriesService, AppQueryServices.ParticipantQueriesService>();
        serviceCollection.AddScoped<appQueryServiceAbstractions.IEventQueriesService, AppQueryServices.EventQueriesService>();

        return serviceCollection;
    }

}
