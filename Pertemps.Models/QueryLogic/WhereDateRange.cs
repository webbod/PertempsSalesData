using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.QueryDecorators.Clauses;
using System;

namespace Pertemps.Models.QueryLogic
{
    public class WhereDateRange : WhereClause<DateTime>
    {
        protected DateTime StartDate => Value;
        protected DateTime EndDate;
        

        public WhereDateRange(DateTime startDate, DateTime endDate, DatabaseField fieldName, IIsAQueryClause andAlso = null)
            : base(fieldName.GetDescription(), startDate, andAlso)
        {
            if(startDate == default || endDate == default)
            {
                throw new ArgumentNullException();
            }

            if (startDate > endDate)
            {
                throw new ArgumentException();
            }

            EndDate = endDate;
        }

        public override string Compile()
        {
            return CompileExpression($" convert(datetime, {FieldName}) between '{StartDate.ToString("yyyy/MM/dd")}' and '{EndDate.ToString("yyyy/MM/dd")}' ");
        }
    }
}
