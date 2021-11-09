using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverCase.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRoverService, RoverService>();
            serviceCollection.AddTransient<IPlateauService, PlateauService>();
            serviceCollection.AddTransient<IDeploymentPositionService, DeploymentPositionService>();
        }
    }
}
