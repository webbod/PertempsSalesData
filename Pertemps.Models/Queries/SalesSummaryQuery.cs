using Pertemps.Common.Enumerations;
using Pertemps.Interfaces.Query;
using Pertemps.Models.QueryFactories;
using Pertemps.Models.QueryParameters;
using System.Text;

namespace Pertemps.Models.Queries
{
    public class SalesSummaryQuery : QueryFactoryOutput
    {
        public SalesSummaryQuery (SalesQueryParameters queryParams, QueryClauseFactory queryClauseFactory)
        {
            var whereClause = queryClauseFactory.Build(queryParams);

            var sb = new StringBuilder();
            sb.AppendLine(SalesTotalsGroupedByColumn(DatabaseField.ItemType, whereClause));
            sb.AppendLine("union all");
            sb.AppendLine(SalesTotalsGroupedByColumn(DatabaseField.OrderPriority, whereClause));
            sb.AppendLine("union all");
            sb.AppendLine(SalesTotalsGroupedByColumn(DatabaseField.SalesChannel, whereClause));
            sb.AppendLine("union all");
            sb.AppendLine(SalesTotalsGroupedByColumn("convert(varchar,convert(datetime, [order date]),23)", DatabaseField.OrderDate.ToString(), whereClause));

            SQL = sb.ToString();
        }

        protected string SalesTotalsGroupedByColumn(DatabaseField column, IIsAQueryClause whereClause)
        {
            return SalesTotalsGroupedByColumn(column.GetDescription(), column.ToString(), whereClause);
        }

        protected string SalesTotalsGroupedByColumn(string column, string dimension, IIsAQueryClause whereClause)
        {
            return $" SELECT {column} as Category, '{dimension}' as Dimension, "
                 + $" {SumAFieldExpression(DatabaseField.UnitsSold)}, {SumAFieldExpression(DatabaseField.TotalCost)}, "
                 + $" {SumAFieldExpression(DatabaseField.TotalRevenue)}, {SumAFieldExpression(DatabaseField.TotalProfit)} "
                 + $" FROM [sales] "
                 + $" WHERE { whereClause.Compile() }"
                 + $" GROUP BY {column} ";
        }

        public static string SumAFieldExpression(DatabaseField field)
        {
            return $" SUM(CONVERT(decimal,{field.GetDescription()})) as {field.ToString()} ";
        }
    }
}
