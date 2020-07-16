using Pertemps.Interfaces.Repository;

namespace Pertemps.Concrete.Interfaces
{
    public interface IIsAPertempsDataService : IIsAUnitOfWork
    {
        IIsASalesDataRepository SalesData { get; }
    }
}