using System.Collections.Generic;
using Pertemps.Models.BusinessModels;
using Pertemps.Models.QueryParameters;

namespace Pertemps.Concrete.Interfaces
{
    public interface IIsASalesDataRepository
    {
        List<SalesSummaryData> GetSalesSummary(SalesQueryParameters queryData);

        List<SalesData> GetDailySales(SalesQueryParameters queryData);
    }
}