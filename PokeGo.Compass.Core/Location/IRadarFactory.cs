using GMap.NET;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Core.Location
{
    public interface IRadarFactory
    {
        IRadar Create(ILocation initialLocation);
    }
}
