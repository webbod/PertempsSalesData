using Pertemps.Repository;
using System.Collections.Generic;
using Dapper;
using Pertemps.Interfaces.Repository;

namespace Pertemps.Concrete.Models.Repositories
{
    public class ADapperRepository<TEntityType> : ASQLRepository<TEntityType>
        where TEntityType: IIsAnEntity
    {
        public ADapperRepository(string connectionString) : base(connectionString)
        {
        }

        protected override IEnumerable<TEntityType> ExecuteQuery(string query)
        {
            using(var connection = GetNewConnection())
            {
                return connection.Query<TEntityType>(query);
            }
        }
    }
}
