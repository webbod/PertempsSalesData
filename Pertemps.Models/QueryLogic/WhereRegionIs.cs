using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.QueryDecorators.Clauses;

namespace Pertemps.Models.QueryLogic
{
    public class WhereRegionIs : WhereClause<string>
    {
        public WhereRegionIs(Region value, IIsAQueryClause andAlso = null) 
            : base(DatabaseField.Region.GetDescription() , value.GetDescription(), andAlso)
        {
        }
    }
}
