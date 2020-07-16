using Pertemps.Interfaces.Factory;

namespace Pertemps.Interfaces.Query
{
    public interface IIsAQueryClause : IIsAFactoryOutput
    {
        void SetClause(IIsAQueryClause clause);

        string Compile();
    }
}