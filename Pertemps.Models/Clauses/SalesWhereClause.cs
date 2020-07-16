using Pertemps.Common.Enumerations;
using Pertemps.Interfaces.Query;
using Pertemps.Models.QueryFactories;
using Pertemps.Models.QueryLogic;
using Pertemps.Models.QueryParameters;
using Pertemps.QueryDecorators.Clauses;

namespace Pertemps.Models.Clauses
{
    public class SalesWhereClause : WhereClause<string>
    {
        public SalesWhereClause(SalesQueryParameters queryParams) : base()
        {
            IIsAQueryClause aggregateClause = new EmptyClause();

            // Either between a these dates or by quarter
            if (!queryParams.StartDate.Equals(default) && !queryParams.EndDate.Equals(default))
            {
                aggregateClause = aggregateClause.ChainClauses(new WhereDateRange(
                    queryParams.StartDate, queryParams.EndDate, DatabaseField.OrderDate));
            }
            else if(queryParams.Year> 0 && !queryParams.Quarter.Equals(Quarter.Undefined))
            {
                aggregateClause = aggregateClause.ChainClauses(new WhereByQuarter(
                    queryParams.Year, queryParams.Quarter, DatabaseField.OrderDate));
            }

            // it doesn't make sense to query by both and country is more specific
            if (!queryParams.Country.Equals(Country.Undefined))
            {
                aggregateClause = aggregateClause.ChainClauses(new WhereCountryIs(queryParams.Country));
            }
            else if (!queryParams.Region.Equals(Region.Undefined))
            {
                aggregateClause = aggregateClause.ChainClauses(new WhereRegionIs(queryParams.Region));
            }

            // these are ranked with the most specific at the bottom
            if (!queryParams.SalesChannel.Equals(SalesChannel.Undefined))
            {
                aggregateClause = aggregateClause.ChainClauses(new WhereSalesChannelIs(queryParams.SalesChannel));
            }
            if (!queryParams.OrderPriority.Equals(OrderPriority.Undefined))
            {
                aggregateClause = aggregateClause.ChainClauses(new WherePriorityIs(queryParams.OrderPriority));
            }
            if (!queryParams.ItemType.Equals(ItemType.Undefined))
            {
                aggregateClause = aggregateClause.ChainClauses(new WhereItemTypeIs(queryParams.ItemType));
            }

            SetClause(aggregateClause);
        }

        public override string Compile()
        {
            return Clause.Compile();
        }
    }
}
