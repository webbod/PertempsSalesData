using System.Collections.Generic;
using Pertemps.Models.Business;
using Pertemps.Models.QueryFactories;

namespace Pertemps.Concrete.Interfaces
{
    public interface IIsASalesDataRepository
    {
        List<SalesSummaryData> GetSalesSummary(SalesQueryParameters queryData);
    }
}