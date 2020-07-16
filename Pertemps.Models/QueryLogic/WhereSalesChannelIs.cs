using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.QueryDecorators.Clauses;

namespace Pertemps.Models.QueryLogic
{
    public class WhereSalesChannelIs : WhereClause<string>
    {
        public WhereSalesChannelIs(SalesChannel value, IIsAQueryClause andAlso = null)
            : base(DatabaseField.SalesChannel.GetDescription(), value.GetDescription(), andAlso)
        {
        }
    }
}