using Csla;
using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CslaIServiceProviderDisposedException
{
    public static class CslaServices
    {

        public static IServiceCollection SetupCslaWithLocalProxy(this IServiceCollection services)
        {
            services.AddCsla(o => o
                .DataPortal(opts => opts.ClientSideDataPortal(client => client
                    .UseLocalProxy()
                    .AutoCloneOnUpdate = false)));

            var prvd = services.BuildServiceProvider();

            Context = prvd.GetService<ApplicationContext>();
            DataPortalFactory = prvd.GetRequiredService<IDataPortalFactory>();

            return services;
        }

        public static ApplicationContext Context { get; private set; }
        public static IDataPortalFactory DataPortalFactory { get; private set; }
    }
}
