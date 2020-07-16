using Pertemps.Interfaces.Query;
using System;

namespace Pertemps.QueryDecorators.Clauses
{
    public class EmptyClause : AQueryClause<string>
    {
        public EmptyClause() : base(null, null, null) { }

        public EmptyClause(string fieldName, string value, IIsAQueryClause clause = null) : base(fieldName, value, clause)
        {
        }

        public override string Compile()
        {
            throw new NotImplementedException();
        }
    }
}
