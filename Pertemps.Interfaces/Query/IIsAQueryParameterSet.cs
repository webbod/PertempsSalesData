using Pertemps.Common.Enumerations;
using Pertemps.Interfaces.Factory;

namespace Pertemps.Interfaces.Query
{
    public interface IIsAQueryParameterSet : IIsAFactoryInput
    {
        QueryName QueryName { get; }
    }
}