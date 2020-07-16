using Pertemps.Concrete.Interfaces;
using Pertemps.Repository;

namespace Pertemps.Concrete.Models.Repositories
{
    public class PertempsData : AUnitOfWork, IIsAPertempsDataSource
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

        public PertempsData(string connectionString) : base(connectionString)
        {
        }
    }
}
