namespace PokeGo.Compass.Core.Models
{
    public interface IPokemon
    {
        ulong Id { get; }
        string Name { get; }
        int Number { get; }
    }
}
