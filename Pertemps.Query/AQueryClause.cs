using Pertemps.Interfaces.Query;
using System;

namespace Pertemps.QueryDecorators
{
    public abstract class AQueryClause<TValueType> : IIsAQueryClause
    {
        protected TValueType Value;
        protected string FieldName;
        protected IIsAQueryClause Clause;

        public Type ClauseType => Clause == null ? null : Clause.GetType();

        public AQueryClause() {  }

        public AQueryClause(string fieldName,  TValueType value, IIsAQueryClause clause = null)
        {
            FieldName = fieldName;
            Value = value;
            Clause = clause;
        }

        public void SetClause(IIsAQueryClause clause)
        {
            Clause = clause;
        }

        public abstract string Compile();

    }
}
