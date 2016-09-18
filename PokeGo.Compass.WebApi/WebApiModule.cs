using System;
using Ninject.Modules;
using PokeGo.Compass.Core.Repositories;
using PokeGo.Compass.Core.Services;
using PokeGo.Compass.Core.Providers;
using PokemonGo.RocketAPI;
using PokeGo.Compass.Core.Location;
using PokeGo.Compass.WebApi.Attributes;
using PokeGo.Compass.Api.Location;
using PokeGo.Compass.Api.Services;
using PokeGo.Compass.Api.Repositories;
using PokeGo.Compass.Api.Providers;
using System.Web.Http.Filters;
using Ninject.Web.WebApi.FilterBindingSyntax;
using Ninject.Web.Mvc.FilterBindingSyntax;
using Ninject;
using Ninject.Web.Common;

namespace PokeGo.Compass.WebApi
{
    public class WebApiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoginService>().To<LoginService>();
            Bind<IPokemonService>().To<PokemonService>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IAuthKeyProvider>().To<AuthKeyProvider>().InRequestScope();
            Bind<IClient>().To<Client>();
            Bind<IRadar>().To<Radar>();
            Bind<IRadarFactory>().To<RadarFactory>();
            Bind<IPokemonClientProvider>().To<PokemonClientProvider>();
            Kernel.BindHttpFilter<AuthKeyFilter>(FilterScope.Controller).InRequestScope();
            Bind<ILocationCalculator>().To<LocationCalculator>().InRequestScope();
            Bind<ILocationFactory>().To<LocationFactory>();
            Bind<IPokemonNearbyProvider>().To<PokemonNearbyProvider>();
            Bind<IPokemonFindProvider>().To<PokemonFindProvider>();
        }
    }
}