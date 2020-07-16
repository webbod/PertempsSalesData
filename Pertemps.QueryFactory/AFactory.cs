using Pertemps.Interfaces.Factory;
using Pertemps.Interfaces.Query;

namespace Pertemps.Factories
{
    public abstract class AFactory<TInputType, TOutputType> :  IIsAFactory<TInputType, TOutputType>
        where TInputType : IIsAFactoryInput
        where TOutputType : IIsAFactoryOutput
    {
        public abstract TOutputType Build(TInputType parameters);
    }
}
