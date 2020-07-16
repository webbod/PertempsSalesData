using Pertemps.Concrete.Interfaces;
using Pertemps.Repository;

namespace Pertemps.Concrete.Models.Repositories
{
    public class PertempsDataService : AUnitOfWork, IIsAPertempsDataService
    {
        private IIsASalesDataRepository _SalesData;


        public IIsASalesDataRepository SalesData
        {
            get
            {
                if (_SalesData == null)
                {
                    _SalesData = new SalesDataRepository(ConnectionString);
                }

                return _SalesData;
            }

            private set
            {
                _SalesData = value;
            }
        }

        public PertempsDataService() { }

        public PertempsDataService(string connectionString) : base(connectionString)
        {
        }
    }
}
