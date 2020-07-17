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

        public static string SumAFieldExpression(DatabaseField field, string castingType = "decimal", bool withAlias = true)
        {
            return $" SUM({CastFieldToNumeric(field, castingType, withAlias:false)}) {GenerateAlias(field, withAlias)} ";
        }

        public static string CastFieldToNumeric(DatabaseField field, string castingType = "decimal", bool withAlias = true)
        {
            return $" CONVERT({castingType},{ field.GetDescription()}) {GenerateAlias(field, withAlias)} ";
        }

        public static string CastFieldToDate(DatabaseField field, bool withAlias = true)
        {
            return $" CONVERT(VARCHAR,CONVERT(DATETIME, {field.GetDescription()}),23) {GenerateAlias(field, withAlias)} ";
        }

        public static string GenerateAlias(DatabaseField field, bool generateAlias)
        {
            return $" {(generateAlias ? $" as {field.ToString()} " : "")} ";
        }
    }
}
