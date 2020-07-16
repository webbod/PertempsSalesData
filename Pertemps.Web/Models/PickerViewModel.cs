using Pertemps.Common.Enumerations;

namespace Pertemps.Web.Models
{
    public class PickerViewModel
    {
        public int Year;
        public Quarter Quarter;
        public Country Country;
        public Region Region;
        public ItemType ItemType;
        public SalesChannel SalesChannel;
        public OrderPriority OrderPriority;

        public PickerViewModel()
        {
            Region = Region.Undefined;
            Country = Country.UnitedKingdom;
            Year = 2010;
            Quarter = Quarter.Q1;
            ItemType = ItemType.Undefined;
            SalesChannel = SalesChannel.Undefined;
            OrderPriority = OrderPriority.Undefined;
        }
    }
}
