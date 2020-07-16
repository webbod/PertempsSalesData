using Pertemps.Interfaces.Query;
using Pertemps.Common.Enumerations;
using System;

namespace Pertemps.Models.QueryParameters
{
    public class SalesQueryParameters : IIsAQueryParameterSet
    {
        public QueryName QueryName { get; set; }
        public Region Region { get; set; }
        public Country Country { get; set; }
        public ItemType ItemType { get; set; }
        public OrderPriority OrderPriority { get; set; }
        public SalesChannel SalesChannel { get; set; }
        public int Year { get; set; }
        public Quarter Quarter { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
