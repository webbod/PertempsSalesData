using System.ComponentModel;

namespace Pertemps.Common.Enumerations
{
    public enum DatabaseField
    {
        [Description("[region]")]
        Region,

        [Description("[country]")]
        Country,

        [Description("[item type]")]
        ItemType,

        [Description("[sales channel]")]
        SalesChannel,

        [Description("[order priority]")]
        OrderPriority,

        [Description("[order date]")]
        OrderDate,

        [Description("[order id]")]
        OrderId,

        [Description("[ship date]")]
        ShipDate,

        [Description("[units sold]")]
        UnitsSold,

        [Description("[unit price]")]
        UnitPrice,

        [Description("[unit cost]")]
        UnitCost,

        [Description("[total revenue]")]
        TotalRevenue,

        [Description("[total cost]")]
        TotalCost,

        [Description("[total profit]")]
        TotalProfit
    }
}
