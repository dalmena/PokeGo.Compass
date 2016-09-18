namespace PokeGo.Compass.Core.Models
{
    public interface ILocation
    {
        double Altitude { get; }
        double Latitude { get; }
        double Longitude { get; }
    }
}
