using PokeGo.Compass.Core.Models;
using System;
using System.Threading.Tasks;

namespace PokeGo.Compass.Core.Location
{
    public interface IRadar
    {
        Task Scan(Func<ILocation, Task> nextScan);
    }
}
