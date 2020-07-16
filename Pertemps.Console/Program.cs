using System.Collections.Generic;
using Pertemps.Common.Enumerations;
using Pertemps.Concrete.Models.Repositories;
using Pertemps.Models.Business;
using Pertemps.Models.Entities;
using Pertemps.Models.QueryFactories;
using Pertemps.Models.QueryParameters;

namespace Pertemps.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryFactory = new QueryFactory();

            var queryData = new SalesQueryParameters
            {
                QueryName = QueryName.SalesSummary,
                Region = Region.SubSaharanAfrica,
                Country = Country.Botswana,
                ItemType = ItemType.Beverages,
                OrderPriority = OrderPriority.L,
                SalesChannel = SalesChannel.Online,
                Quarter = Quarter.Q1,
                Year = 2016
            };
           
            var query = queryFactory.Build(queryData);

            string cnn = @"Server=localhost\sqlexpress;Database=Test;User Id=test;Password=test;";
            
            var data = GetSalesSummary(queryData, cnn);

            System.Console.ReadLine();
        }


        public static List<SalesSummaryData> GetSalesSummary(SalesQueryParameters queryData, string cnn)
        {
            var pertempsData = new PertempsDataService(cnn);
            return pertempsData.SalesData.GetSalesSummary(queryData);
        }


  
    }
}
