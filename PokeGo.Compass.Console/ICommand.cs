namespace PokeGo.Compass.Console
{
    public interface ICommand
    {
        bool Recognize();
        ICommandOutput Execute();
    }
}
