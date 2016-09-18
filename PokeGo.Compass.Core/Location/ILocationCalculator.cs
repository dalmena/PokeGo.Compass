using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Core.Location
{
    public interface ILocationCalculator
    {
        double GetDistanceInMeters(ILocation start, ILocation end);
        ILocation AddMetersToLocation(ILocation location, double distance, double bearing);
    }
}
