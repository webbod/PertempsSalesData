using System.ComponentModel;

namespace Pertemps.Common.Enumerations
{
    public enum Region
    {
        [Description("Undefined")]
        Undefined,

        [Description("Asia")]
        Asia,

        [Description("Australia and Oceania")]
        AustraliaAndOceania,
        
        [Description("Central America and the Caribbean")]
        CentralAmericaAndtheCaribbean,

        [Description("Europe")]
        Europe,

        [Description("Middle East and North Africa")]
        MiddleEastAndNorthAfrica,

        [Description("North America")]
        NorthAmerica,

        [Description("Sub-Saharan Africa")]
        SubSaharanAfrica
    }
}
