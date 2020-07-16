using Pertemps.Common.Enumerations;
using Pertemps.Interfaces.Repository;

namespace Pertemps.Models.Entities
{
    public class SalesSummaryEntity : IIsSalesData
    {
        public string Category { get; set; }
        public DatabaseField Dimension { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
