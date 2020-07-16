using Pertemps.Interfaces.Query;

namespace Pertemps.Interfaces.Factory
{
    public interface IIsAFactory<TInputType, TOutputType>
        where TInputType : IIsAFactoryInput
        where TOutputType : IIsAFactoryOutput
    {
        TOutputType Build(TInputType parameters);
    }
}