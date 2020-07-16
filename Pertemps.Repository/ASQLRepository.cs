using Pertemps.Interfaces.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pertemps.Repository
{
    public abstract class ASQLRepository<TEntityType> : IIsARepository
        where TEntityType : IIsAnEntity
    {
        protected string ConnectionString { get; private set;}

        public ASQLRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection GetNewConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        protected abstract IEnumerable<TReturnType> ExecuteQuery<TReturnType>(string query) where TReturnType : TEntityType;
    }
}

