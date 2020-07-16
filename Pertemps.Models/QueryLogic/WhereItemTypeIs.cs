using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.QueryDecorators.Clauses;

namespace Pertemps.Models.QueryLogic
{
    public class WhereItemTypeIs : WhereClause<string>
    {
        public WhereItemTypeIs(ItemType value, IIsAQueryClause andAlso = null) 
            : base(DatabaseField.ItemType.GetDescription() , value.GetDescription(), andAlso)
        {
        }
    }
}
