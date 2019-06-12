using SIS.MvcFramework;
using SIS.MvcFramework.Routing;
using Torshia.Data;
using Torshia.Services;

namespace Torshia.App
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new TorshiaDBContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(SIS.MvcFramework.DependencyContainer.IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
        }
    }
}
