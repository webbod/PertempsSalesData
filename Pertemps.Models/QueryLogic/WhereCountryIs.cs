using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.QueryDecorators.Clauses;

namespace Pertemps.Models.QueryLogic
{
    public class WhereCountryIs : WhereClause<string>
    {
        public WhereCountryIs(Country value, IIsAQueryClause andAlso = null) 
            : base(DatabaseField.Country.GetDescription(), value.GetDescription(), andAlso)
        {
        }
    }
}
