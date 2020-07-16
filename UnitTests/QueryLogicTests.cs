using Pertemps.Common.Enumerations;
using Pertemps.Models.QueryLogic;
using System;
using Xunit;

namespace UnitTests
{
    public class QueryLogicTests
    {
        [Fact]
        public void WhereDateRangeDoesNotAcceptNullDates()
        {
            Assert.Throws<ArgumentNullException>(() => new WhereDateRange(default(DateTime), default(DateTime), DatabaseField.OrderDate));
        }

        [Fact]
        public void WhereDateRangeDoesNotAcceptDatesInTheWrongOrder()
        {
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(-1);
            Assert.Throws<ArgumentException>(() => new WhereDateRange(startDate, endDate, DatabaseField.OrderDate));
        }

        [Fact]
        public void WhereDateRangeCompilesCorrectly()
        {
            var startDate = new DateTime(2011, 01, 01);
            var endDate = new DateTime(2011, 03, 31);

            var objectUnderTest = new WhereDateRange(startDate, endDate, DatabaseField.OrderDate);
            var actual = objectUnderTest.Compile().Trim();
            var expected = "convert(datetime, [order date]) between '2011/01/01' and '2011/03/31'";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhereByQuarterExpectsYearToBeAtLeast2010()
        {
            var year = 2009;
            Assert.Throws<ArgumentOutOfRangeException>(() => new WhereByQuarter(year, Quarter.Q1, DatabaseField.OrderDate));
        }

        [Fact]
        public void WhereByQuarterExpectsYearToBeNoMoreThanTheCurrentYear()
        {
            var year = DateTime.Now.Year + 1;
            Assert.Throws<ArgumentOutOfRangeException>(() => new WhereByQuarter(year, Quarter.Q1, DatabaseField.OrderDate));
        }
        
        [Theory]
        [InlineData(2011, Quarter.Q1, DatabaseField.OrderDate, "convert(datetime, [order date]) between '2011/01/01' and '2011/03/31'")]
        [InlineData(2011, Quarter.Q2, DatabaseField.OrderDate, "convert(datetime, [order date]) between '2011/04/01' and '2011/06/30'")]
        [InlineData(2011, Quarter.Q3, DatabaseField.OrderDate, "convert(datetime, [order date]) between '2011/07/01' and '2011/09/30'")]
        [InlineData(2011, Quarter.Q4, DatabaseField.OrderDate, "convert(datetime, [order date]) between '2011/10/01' and '2011/12/31'")]
        public void WhereByQuarterCompilesCorrectly(int year, Quarter quarter, DatabaseField field, string expected)
        {
            var objectUnderTest = new WhereByQuarter(year, quarter, field);
            var actual = objectUnderTest.Compile().Trim();

            Assert.Equal(expected, actual);
        }
    }
}
