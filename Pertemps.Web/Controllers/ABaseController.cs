using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pertemps.Concrete.Interfaces;
using Pertemps.ConcreteModels;
using Pertemps.Models.QueryParameters;
using Microsoft.AspNetCore.Http;
using Pertemps.Common.Enumerations;
using Pertemps.Web.Models;
using System;

namespace Pertemps.Web.Controllers
{
    public class ABaseController : Controller
    {
        private readonly DatabaseOptions _DatabaseOptions;
        protected IIsAPertempsDataService DataService;

        public ABaseController( 
            IIsAPertempsDataService dataService,
            IOptions<DatabaseOptions> databaseOptions)
        {
            _DatabaseOptions = databaseOptions.Value;
            DataService = dataService;

            DataService.Initalise(_DatabaseOptions);
        }

        protected void CacheQueryParams(SalesQueryParameters queryParams)
        {
            HttpContext.Session.SetInt32("year", (int)queryParams.Year);
            HttpContext.Session.SetInt32("quarter", (int)queryParams.Quarter);
            HttpContext.Session.SetInt32("region", (int)queryParams.Region);
            HttpContext.Session.SetInt32("country", (int)queryParams.Country);
            HttpContext.Session.SetInt32("itemType", (int)queryParams.ItemType);
            HttpContext.Session.SetInt32("salesChannel", (int)queryParams.SalesChannel);
            HttpContext.Session.SetInt32("orderPriority", (int)queryParams.OrderPriority);
        }

        protected SalesQueryParameters GetQueryParams()
        {
            var queryParams = new SalesQueryParameters
            {
                Year = HttpContext.Session.GetInt32("year").Value,
                Quarter = (Quarter)HttpContext.Session.GetInt32("quarter").Value,
                Region = (Region)HttpContext.Session.GetInt32("region").Value,
                Country = (Country)HttpContext.Session.GetInt32("country").Value,
                ItemType = (ItemType)HttpContext.Session.GetInt32("itemType").Value,
                SalesChannel = (SalesChannel)HttpContext.Session.GetInt32("salesChannel").Value,
                OrderPriority = (OrderPriority)HttpContext.Session.GetInt32("orderPriority").Value
            };

            return queryParams;
        }

        protected PickerViewModel GetPickerModel()
        {
            var model = new PickerViewModel();

            try
            {
                var queryParams = GetQueryParams();

                if (queryParams.Year > 2000 && queryParams.Quarter != Quarter.Undefined)
                {
                    model.Year = queryParams.Year;
                    model.Quarter = queryParams.Quarter;
                }

                if(!queryParams.Country.Equals(Country.Undefined) || !queryParams.Region.Equals(Region.Undefined))
                {
                    model.Country = queryParams.Country;
                    model.Region = queryParams.Region;
                }

                model.ItemType = queryParams.ItemType;
                model.SalesChannel = queryParams.SalesChannel;
                model.OrderPriority = queryParams.OrderPriority;
            }
            catch(Exception)
            {
                // just means a qurey hasn't been run yet
            }

            return model;
        }
    }
}
