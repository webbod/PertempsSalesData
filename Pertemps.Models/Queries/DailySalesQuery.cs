using Pertemps.Common.Enumerations;
using Pertemps.Interfaces.Query;
using Pertemps.Models.QueryFactories;
using Pertemps.Models.QueryParameters;
using System.Text;

namespace Pertemps.Models.Queries
{
    public class DailySalesQuery : QueryFactoryOutput
    {
        public DailySalesQuery(SalesQueryParameters queryParams, QueryClauseFactory queryClauseFactory)
        {
            var whereClause = queryClauseFactory.Build(queryParams);

            var sb = new StringBuilder();
            sb.Append($"SELECT {DatabaseField.Region.GetDescription()},{DatabaseField.Country.GetDescription()},{DatabaseField.ItemType.GetDescription()},");
            sb.Append($"{DatabaseField.SalesChannel.GetDescription()},{DatabaseField.OrderPriority.GetDescription()},{DatabaseField.OrderId.GetDescription()},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.OrderDate)},{CastFieldToNumeric(DatabaseField.ShipDate)},{CastFieldToNumeric(DatabaseField.UnitPrice)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.UnitCost)},{CastFieldToNumeric(DatabaseField.UnitsSold)},{CastFieldToNumeric(DatabaseField.TotalRevenue)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.TotalCost)},{CastFieldToNumeric(DatabaseField.TotalProfit)}");
            sb.Append($" FROM [sales] ");
            sb.Append($" WHERE { whereClause.Compile() }");
            SQL = sb.ToString();

        }
    }
}
