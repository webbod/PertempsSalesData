using Pertemps.Interfaces.Query;

namespace Pertemps.QueryDecorators.Clauses
{
    public static class QueryClauseExtensions
    {
        public static IIsAQueryClause ChainClauses(this IIsAQueryClause current, IIsAQueryClause next)
        {
            if (!(current is EmptyClause))
            {
                next.SetClause(current);
            }

            return next;
        }
    }
}
