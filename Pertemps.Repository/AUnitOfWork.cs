using Pertemps.Interfaces.Repository;

namespace Pertemps.Repository
{
    public abstract class AUnitOfWork : IIsAUnitOfWork
    {
        protected string ConnectionString { get; private set; }
        
        public AUnitOfWork() { }

        public AUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Initalise(IIsASetOfDatabaseOptions options)
        {
            ConnectionString = options.ConnectionString;
        }
    }
}
