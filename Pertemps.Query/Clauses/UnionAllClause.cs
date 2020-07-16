using Pertemps.Interfaces.Query;
using System;

namespace Pertemps.QueryDecorators.Clauses
{
    public class UnionAllClause : AQueryClause<string>
    {
        protected IIsAQueryClause AndAlso { get { return Clause; } }

        public UnionAllClause(string sql, IIsAQueryClause andAlso = null) : base("unionQuery", sql, andAlso)
        {
            if(andAlso != null && andAlso.GetType().IsAssignableFrom(this.GetType()))
            {
                throw new InvalidCastException("These expressions are incompatible");
            }
        }

        public override string Compile()
        {
            return $" {Value} {(AndAlso != null ? $"\n UNION ALL \n{AndAlso.Compile()} " : "")}";
        }
    }
}
