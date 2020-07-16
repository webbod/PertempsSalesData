namespace Pertemps.Interfaces.Repository
{
    public interface IIsAUnitOfWork
    {
        void Initalise(IIsASetOfDatabaseOptions options);
    }
}
