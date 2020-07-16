using Pertemps.Interfaces.Repository;

namespace Pertemps.Repository
{
    public class ASetOfDatabaseOptions : IIsASetOfDatabaseOptions
    {
        public string ConnectionString { get; set; }
    }
}
