using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pertemps.Models.QueryFactories;

namespace Pertemps.Web.Controllers
{
    public class SalesDataController : Controller
    {
        public IActionResult Index(SalesQueryParameters queryParams)
        {
            ViewData.Add("QueryParams", queryParams);
            return View("Index");
        }

        public IActionResult Report(SalesQueryParameters queryParams)
        {
            return Index(queryParams);
        }
    }
}