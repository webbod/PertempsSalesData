using Pertemps.Common.Enumerations;
using Pertemps.Models.BusinessModels;
using Pertemps.Models.QueryParameters;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pertemps.Web.Models
{
    public class SalesSummaryViewModel
    {
        public string BaseUrl;
        public SalesQueryParameters QueryParams;

        public List<SalesSummaryData> DivisionData;
        public List<SalesSummaryData> SalesChannelData;
        public List<SalesSummaryData> OrderPriorityData;
        public List<SalesSummaryData> DailyData;

        public string Geography;
        public string Period;
        public string DivisionCaption;
        public string SalesChannelCaption;
        public string OrderPriorityCaption;

        public SalesSummaryViewModel(string baseUrl, SalesQueryParameters queryParams, List<SalesSummaryData> data)
        {
            BaseUrl = baseUrl;
            QueryParams = queryParams;

            DivisionData = data.Where(d => d.Dimension == DatabaseField.ItemType).ToList();
            SalesChannelData = data.Where(d => d.Dimension == DatabaseField.SalesChannel).ToList();
            OrderPriorityData = data.Where(d => d.Dimension == DatabaseField.OrderPriority).ToList();
            DailyData = data.Where(d => d.Dimension == DatabaseField.OrderDate).ToList();

            Geography = queryParams.Country.Equals(Country.Undefined) ?
                queryParams.Region.GetDescription() :
                queryParams.Country.GetDescription();

            if(Geography == "Undefined") { Geography = "Worldwide"; }

            Period = $"{queryParams.Year} - {queryParams.Quarter}";

            DivisionCaption = $"{ (queryParams.ItemType.Equals(ItemType.Undefined) ? " All Divisions " : queryParams.ItemType.GetDescription()) } ";
            SalesChannelCaption = $" { (queryParams.SalesChannel.Equals(SalesChannel.Undefined) ? " All Channels " : queryParams.SalesChannel.GetDescription()) } ";
            OrderPriorityCaption = $" { (queryParams.OrderPriority.Equals(OrderPriority.Undefined) ? " Any Priority " : queryParams.OrderPriority.GetDescription()) } ";
        }

        public string BuildURL (DatabaseField section, string value)
        {
            var region = QueryParams.Region.Equals(Country.Undefined) ? "National" : QueryParams.Region.ToString();
            var country = QueryParams.Country.Equals(Country.Undefined) ? "Regional" : QueryParams.Country.ToString();

            var sb = new StringBuilder($"{BaseUrl}{QueryParams.Year}/{QueryParams.Quarter}/{region}/{country}/");

            sb.Append($"{(section == DatabaseField.ItemType ? value.Replace(" ","_") : QueryParams.ItemType.ToString())}/");
            sb.Append($"{(section == DatabaseField.SalesChannel ? value.Replace(" ", "_") : QueryParams.SalesChannel.ToString())}/");
            sb.Append($"{(section == DatabaseField.OrderPriority ? value.Replace(" ", "_") : QueryParams.OrderPriority.ToString())}/");

            return sb.ToString();
        }
    }
}
