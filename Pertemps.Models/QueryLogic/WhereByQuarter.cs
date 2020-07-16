using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using Pertemps.QueryDecorators.Clauses;
using System;

namespace Pertemps.Models.QueryLogic
{
    public class WhereByQuarter : WhereClause<Quarter>
    {
        protected Quarter Quarter => Value;
        protected int Year;

        public string StartDate => CalculateStartDate();

        public string EndDate => CalculateEndDate();

        public WhereByQuarter(int year, Quarter quarter, DatabaseField fieldName, IIsAQueryClause andAlso = null)
            : base(fieldName.GetDescription(), quarter, andAlso)
        {
            if(year < 2010 || year > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException();
            }
            Year = year < 100 ? year + 2000 : year;
        }

        protected string CalculateStartDate()
        {
            switch (Quarter)
            {
                case Quarter.Q1: return $"{Year}/01/01";
                case Quarter.Q2: return $"{Year}/04/01";
                case Quarter.Q3: return $"{Year}/07/01";
                case Quarter.Q4: return $"{Year}/10/01";
            }

            throw new ArgumentException();
        }

        protected string CalculateEndDate()
        {
            switch (Quarter)
            {
                case Quarter.Q1: return $"{Year}/03/31";
                case Quarter.Q2: return $"{Year}/06/30"; 
                case Quarter.Q3: return $"{Year}/09/30";
                case Quarter.Q4: return $"{Year}/12/31"; 
            }

            throw new ArgumentException();
        }

        public override string Compile()
        {
            return CompileExpression($" convert(datetime, {FieldName}) between '{StartDate}' and '{EndDate}' ");
        }
    }
}
