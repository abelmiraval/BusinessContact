using BusinessContact.DataAccess.Implementations;
using BusinessContact.DataAccess.Interfaces;
using BusinessContact.Services.Implementations;
using BusinessContact.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessContact.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>()
                .AddTransient<IContactService, ContactService>();

            return services;
        }
    }
}