using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.Factories;
using System;
using Pertemps.Models.Clauses;
using Pertemps.Models.QueryParameters;

namespace Pertemps.Models.QueryFactories
{
    public class QueryClauseFactory : AFactory<IIsAQueryParameterSet, IIsAQueryClause>
    {
        public override IIsAQueryClause Build(IIsAQueryParameterSet parameters)
        {
            switch(parameters.QueryName)
            {
                case QueryName.SalesSummary:
                    return new SalesWhereClause(parameters as SalesQueryParameters);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
