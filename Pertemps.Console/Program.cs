using Pertemps.Common.Enumerations;
using Pertemps.Concrete.Models.Repositories;
using Pertemps.Models.BusinessModels;
using Pertemps.Models.QueryFactories;
using Pertemps.Models.QueryParameters;
using System;
using System.Collections.Generic;

namespace Pertemps.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryFactory = new QueryFactory();

            var queryData = new SalesQueryParameters
            {
                QueryName = QueryName.DailySales,
                Region = Region.SubSaharanAfrica,
                //Country = Country.Botswana,
                //ItemType = ItemType.Beverages,
                //OrderPriority = OrderPriority.L,
                //SalesChannel = SalesChannel.Online,
                StartDate = new DateTime(2012,03,01)
            };
           
            var query = queryFactory.Build(queryData);

            string cnn = @"Server=localhost\sqlexpress;Database=Test;User Id=test;Password=test;";
            
            var data = GetSalesSummary(queryData, cnn);

            System.Console.ReadLine();
        }


        public static List<SalesData> GetSalesSummary(SalesQueryParameters queryData, string cnn)
        {
            var pertempsData = new PertempsDataService(cnn);
            return pertempsData.SalesData.GetDailySales(queryData);
        }


  
    }
}
