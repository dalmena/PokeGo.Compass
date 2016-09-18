namespace PokeGo.Compass.Core.Models
{
    public interface IPokemonFound
    {
        IPokemon Pokemon { get; set; }
        ILocation Location { get; set; }
    }
}
