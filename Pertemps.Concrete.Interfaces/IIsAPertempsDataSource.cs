namespace Pertemps.Concrete.Interfaces
{
    public interface IIsAPertempsDataSource
    {
        IIsASalesDataRepository SalesData { get; }
    }
}