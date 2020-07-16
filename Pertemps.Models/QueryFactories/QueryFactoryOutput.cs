using Pertemps.Common.Enumerations;
using Pertemps.Interfaces.Query;

namespace Pertemps.Models.QueryFactories
{
    public class QueryFactoryOutput : IIsAQuery
    {
        public string SQL { get; protected set; }

        public QueryFactoryOutput() { }

        public QueryFactoryOutput(string sql)
        {
            SQL = sql;
        }

        public static string SumAFieldExpression(DatabaseField field, string castingType = "decimal")
        {
            return $" SUM({CastFieldToNumeric(field, castingType)}) as {field.ToString()} ";
        }

        public static string CastFieldToNumeric(DatabaseField field, string castingType = "decimal")
        {
            return $" CONVERT({castingType},{ field.GetDescription()} ";
        }

        public static string CastFieldToDate(DatabaseField field)
        {
            return $" CONVERT(VARCHAR,CONVERT(DATETIME, {field.GetDescription()}),23) ";
        }
    }
}
