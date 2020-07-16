using Pertemps.Common.Enumerations;
using Pertemps.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pertemps.Models.Business
{
    public class SalesSummaryData : SalesData
    {
        public decimal UnitsSoldPercentage { get; set; }
        public decimal TotalRevenuePercentage { get; set; }
        public decimal TotalCostPercentage { get; set; }
        public decimal TotalProfitPercentage { get; set; }
    }

    public static class SalesSummaryDataExtensions
    {
        public static List<SalesSummaryData> ComputePercentages(this List<SalesSummaryData> data, DatabaseField column)
        {
            var dimension = column.ToString();
            var dimensionData = data.Where(r => r.Dimension == dimension);

            var totals = new SalesSummaryData
            {
                Category = "**TOTAL**",
                Dimension = dimension,
                UnitsSold = dimensionData.Sum(r => r.UnitsSold),
                TotalRevenue = dimensionData.Sum(r => r.TotalRevenue),
                TotalCost = dimensionData.Sum(r => r.TotalCost),
                TotalProfit = dimensionData.Sum(r => r.TotalProfit)
            };

            foreach (var category in dimensionData)
            {
                category.UnitsSoldPercentage = Math.Round(category.UnitsSold / totals.UnitsSold * 100, 2);
                category.TotalRevenuePercentage = Math.Round(category.TotalRevenue / totals.TotalRevenue * 100, 2);
                category.TotalCostPercentage = Math.Round(category.TotalCost / totals.TotalCost * 100, 2);
                category.TotalProfitPercentage = Math.Round(category.TotalProfit / totals.TotalProfit * 100, 2);
            }

            return data;
        }
    }
}
