using Pertemps.Common.Enumerations;
using Pertemps.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class SalesDataSummaryExtensionsTests
    {
        protected SalesSummaryData TestCaseFactory(int value)
        {
            return new SalesSummaryData
            {
                Category = $"line{value}",
                Dimension = DatabaseField.ItemType,
                TotalCost = value,
                TotalProfit = value,
                TotalRevenue = value,
                UnitsSold = value
            };
        }

        [Fact]
        public void ComputedPercentagesAddUp()
        {
            var objectUnderTest = Enumerable.Range(1, 10).Select(i => TestCaseFactory(i)).ToList();

            var expected = 100m;

            objectUnderTest.ComputePercentages(DatabaseField.ItemType);
            var actualTotalCostpercentage = objectUnderTest.Sum(i => i.TotalCostPercentage);
            Assert.Equal(expected, actualTotalCostpercentage);

            objectUnderTest.ComputePercentages(DatabaseField.ItemType);
            var actualTotalProfitPercentage = objectUnderTest.Sum(i => i.TotalProfitPercentage);
            Assert.Equal(expected, actualTotalProfitPercentage);

            objectUnderTest.ComputePercentages(DatabaseField.ItemType);
            var actualTotalRevenuePercentage = objectUnderTest.Sum(i => i.TotalRevenuePercentage);
            Assert.Equal(expected, actualTotalRevenuePercentage);

            objectUnderTest.ComputePercentages(DatabaseField.ItemType);
            var actualUnitsSoldPercentage = objectUnderTest.Sum(i => i.UnitsSoldPercentage);
            Assert.Equal(expected, actualUnitsSoldPercentage);
        }

        [Fact]
        public void ComputedPercentagesAreCorrect()
        {
            var objectUnderTest = Enumerable.Range(1, 10).Select(i => TestCaseFactory(i)).ToList();
            objectUnderTest.ComputePercentages(DatabaseField.ItemType);

            var line1 = objectUnderTest.FirstOrDefault(i => i.Category == "line1").TotalRevenuePercentage;
            var line2 = objectUnderTest.FirstOrDefault(i => i.Category == "line2").TotalRevenuePercentage;
            var line3 = objectUnderTest.FirstOrDefault(i => i.Category == "line3").TotalRevenuePercentage;
            var line4 = objectUnderTest.FirstOrDefault(i => i.Category == "line4").TotalRevenuePercentage;
            var line5 = objectUnderTest.FirstOrDefault(i => i.Category == "line5").TotalRevenuePercentage;
            var line6 = objectUnderTest.FirstOrDefault(i => i.Category == "line6").TotalRevenuePercentage;
            var line7 = objectUnderTest.FirstOrDefault(i => i.Category == "line7").TotalRevenuePercentage;
            var line8 = objectUnderTest.FirstOrDefault(i => i.Category == "line8").TotalRevenuePercentage;
            var line9 = objectUnderTest.FirstOrDefault(i => i.Category == "line9").TotalRevenuePercentage;
            var line10 = objectUnderTest.FirstOrDefault(i => i.Category == "line10").TotalRevenuePercentage;

            var expected = Math.Round(line2);
            var actual = Math.Round(line10 - line8);

            Assert.Equal(expected, actual);

            expected = Math.Round(line7 + line1 + line8 + line2,1);
            actual = Math.Round(line3 + line6 + line9,1);

            Assert.Equal(expected, actual);

            expected = Math.Round(line4 + line5,1);
            actual = Math.Round(line2 + line7,1);

            Assert.Equal(expected, actual);
        }
    }
}
