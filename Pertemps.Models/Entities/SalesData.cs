using Pertemps.Interfaces.Repository;

namespace Pertemps.Models.Entities
{
    public class SalesData : IIsAnEntity
    {
        public string Category { get; set; }
        public string Dimension { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
