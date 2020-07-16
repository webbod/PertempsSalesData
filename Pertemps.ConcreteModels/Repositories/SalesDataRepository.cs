using Pertemps.Common.Enumerations;
using Pertemps.Concrete.Interfaces;
using Pertemps.Interfaces.Repository;
using Pertemps.Models.BusinessModels;
using Pertemps.Models.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pertemps.Concrete.Models.Repositories
{
    public class SalesDataRepository : ADapperRepository<IIsSalesData>, IIsASalesDataRepository
    {
        public SalesDataRepository(string connectionString) : base(connectionString) { }

        public List<SalesData> GetDailySales(SalesQueryParameters queryData)
        {
            if (queryData.QueryName != QueryName.DailySales)
            {
                throw new ArgumentException();
            }

            return ExecuteQuery<SalesData>(queryData)?.ToList();
        }

        public List<SalesSummaryData> GetSalesSummary(SalesQueryParameters queryData)
        {
            if(queryData.QueryName != QueryName.SalesSummary)
            {
                throw new ArgumentException();
            }

            return ExecuteQuery<SalesSummaryData>(queryData)
                .ToList()
                .ComputePercentages(DatabaseField.ItemType)
                .ComputePercentages(DatabaseField.OrderPriority)
                .ComputePercentages(DatabaseField.SalesChannel);
        }
    }
}
