using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.QueryDecorators.Clauses;

namespace Pertemps.Models.QueryLogic
{
    public class WherePriorityIs : WhereClause<string>
    {
        public WherePriorityIs(OrderPriority value, IIsAQueryClause andAlso = null)
            : base(DatabaseField.OrderPriority.GetDescription(), value.GetDescription(), andAlso)
        {
        }
    }
}