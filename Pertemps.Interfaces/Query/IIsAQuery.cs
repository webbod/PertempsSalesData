using Pertemps.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pertemps.Interfaces.Query
{
    public interface IIsAQuery :IIsAFactoryOutput
    {
        string SQL { get; }
    }
}
