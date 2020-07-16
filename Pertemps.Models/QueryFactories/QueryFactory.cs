using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.Factories;
using System;
using Pertemps.Models.Queries;
using Pertemps.Models.QueryParameters;

namespace Pertemps.Models.QueryFactories
{
    public class QueryFactory : AFactory<IIsAQueryParameterSet, QueryFactoryOutput>
    {
        protected QueryClauseFactory QueryClauseFactory = new QueryClauseFactory();

        public override QueryFactoryOutput Build(IIsAQueryParameterSet parameters)
        {
            switch(parameters.QueryName)
            {
                case QueryName.DailySales:
                    return new DailySalesQuery(parameters as SalesQueryParameters, QueryClauseFactory);

                case QueryName.SalesSummary:
                    return new SalesSummaryQuery(parameters as SalesQueryParameters, QueryClauseFactory);

                default:
                    throw new ArgumentException();
            }
        }


    }
}
