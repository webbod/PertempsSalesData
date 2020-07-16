using Pertemps.Interfaces.Factory;

namespace Pertemps.Interfaces.Query
{
    public interface IIsAQuery :IIsAFactoryOutput
    {
        string SQL { get; }
    }
}
