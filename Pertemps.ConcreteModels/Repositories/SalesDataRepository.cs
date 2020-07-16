using Dapper;
using Pertemps.Common.Enumerations;
using Pertemps.Concrete.Interfaces;
using Pertemps.Models.Business;
using Pertemps.Models.Entities;
using Pertemps.Models.QueryFactories;
using System.Collections.Generic;
using System.Linq;

namespace Pertemps.Concrete.Models.Repositories
{
    public class SalesDataRepository : ADapperRepository<SalesData>, IIsASalesDataRepository
    {
        public SalesDataRepository(string connectionString) : base(connectionString)
        {
        }

        public List<SalesSummaryData> GetSalesSummary(SalesQueryParameters queryData)
        {
            var queryFactory = new QueryFactory();
            var querySQL = queryFactory.Build(queryData).SQL;

            using (var connection = GetNewConnection())
            {
                var results = connection.Query<SalesSummaryData>(querySQL).ToList();

                results
                    .ComputePercentages(DatabaseField.ItemType)
                    .ComputePercentages(DatabaseField.OrderPriority)
                    .ComputePercentages(DatabaseField.SalesChannel);

                return results;
            }
        }
    }
}
