using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Core.Location
{
    public interface ILocationFactory
    {
        ILocation Create(double latitude, double longitude);
        ILocation Create(double latitude, double longitude, double altitude);
    }
}
