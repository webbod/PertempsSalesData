using Pertemps.Interfaces.Query;

namespace Pertemps.Models.QueryFactories
{
    public class QueryFactoryOutput : IIsAQuery
    {
        public string SQL { get; protected set; }

        public QueryFactoryOutput() { }

        public QueryFactoryOutput(string sql)
        {
            SQL = sql;
        }
    }
}
