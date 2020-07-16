using Pertemps.Interfaces.Query;
using System;

namespace Pertemps.QueryDecorators.Clauses
{
    public class WhereClause<TValueType> : AQueryClause<TValueType>
    {
        protected IIsAQueryClause AndAlso => Clause;

        public WhereClause() : base()
        {

        }

        public WhereClause(string fieldName, TValueType value, IIsAQueryClause andAlso = null) : base(fieldName, value, andAlso)
        {
            if(andAlso != null && andAlso.GetType().IsAssignableFrom(this.GetType()))
            {
                throw new InvalidCastException("These expressions are incompatible");
            }
        }

        public override string Compile()
        {
            return CompileExpression($" {FieldName} = '{Value}'");
        }

        protected string CompileExpression(string expression)
        {
            return $" {expression} {AndTheRest()} ";
        }

        protected string AndTheRest()
        {
            return (AndAlso != null ? $" AND {AndAlso.Compile()} " : "");
        }
    }
}
