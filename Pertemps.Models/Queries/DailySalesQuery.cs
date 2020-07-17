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
            sb.Append($"SELECT {DatabaseField.Region.GetDescription()} as {DatabaseField.Region.ToString()},");
            sb.Append($"{DatabaseField.Country.GetDescription()} as {DatabaseField.Country.ToString()},");
            sb.Append($"{DatabaseField.ItemType.GetDescription()} as {DatabaseField.ItemType.ToString()},");
            sb.Append($"{DatabaseField.SalesChannel.GetDescription()} as {DatabaseField.SalesChannel.ToString()},");
            sb.Append($"{DatabaseField.OrderPriority.GetDescription()} as {DatabaseField.OrderPriority.ToString()},");
            sb.Append($"{DatabaseField.OrderId.GetDescription()} as {DatabaseField.OrderId.ToString()},");
            sb.Append($"{CastFieldToDate(DatabaseField.OrderDate)},");
            sb.Append($"{CastFieldToDate(DatabaseField.ShipDate)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.UnitPrice)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.UnitCost)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.UnitsSold)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.TotalRevenue)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.TotalCost)},");
            sb.Append($"{CastFieldToNumeric(DatabaseField.TotalProfit)}");
            sb.Append($" FROM [sales] ");
            sb.Append($" WHERE { whereClause.Compile() }");
            SQL = sb.ToString();

        }
    }
}
