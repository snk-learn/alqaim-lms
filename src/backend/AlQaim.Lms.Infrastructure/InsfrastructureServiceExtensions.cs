using AlQaim.Lms.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AlQaim.Lms.Infrastructure;

public static class InsfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }

}
