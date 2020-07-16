using Pertemps.Repository;
using System.Collections.Generic;
using Dapper;
using Pertemps.Interfaces.Repository;
using Pertemps.Models.QueryFactories;
using Pertemps.Interfaces.Query;

namespace Pertemps.Concrete.Models.Repositories
{
    public class ADapperRepository<TEntityType> : ASQLRepository<TEntityType>
        where TEntityType : IIsAnEntity
    {
        private QueryFactory _QueryFactory;

        public ADapperRepository(string connectionString) : base(connectionString)
        {
            _QueryFactory = new QueryFactory();
        }

        protected override IEnumerable<TReturnType> ExecuteQuery<TReturnType>(string query)
        {
            using (var connection = GetNewConnection())
            {
                return connection.Query<TReturnType>(query);
            }
        }

        protected IEnumerable<TReturnType> ExecuteQuery<TReturnType>(IIsAQueryParameterSet queryData)
            where TReturnType : TEntityType
        {
            return ExecuteQuery<TReturnType>(_QueryFactory.Build(queryData).SQL);
        }
    }
}
