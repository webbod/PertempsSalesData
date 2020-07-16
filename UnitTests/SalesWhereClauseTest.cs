using Pertemps.Common.Enumerations;
using Pertemps.Models.Clauses;
using Pertemps.Models.QueryLogic;
using Pertemps.Models.QueryParameters;
using Pertemps.QueryDecorators.Clauses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class SalesWhereClauseTest
    {

        protected  SalesQueryParameters TestCaseFactory(string testCaseName)
        {
            switch (testCaseName)
            {
                case "period":
                    return new SalesQueryParameters { Year = 2010, Quarter = Quarter.Q1 };
                case "date":
                    return new SalesQueryParameters { 
                        StartDate = new DateTime(2012,05,21), 
                        EndDate= new DateTime(2013,09,17) 
                    };
                case "periodAndDate":
                    return new SalesQueryParameters { 
                        Year = 2010, Quarter = Quarter.Q1, 
                        StartDate = new DateTime(2012,05,21), 
                        EndDate = new DateTime(2013,09,17) 
                    };

                case "noPeriodOrDate":
                    return new SalesQueryParameters { Country = Country.Afghanistan };

                case "country":
                    return new SalesQueryParameters { 
                        Country = Country.Afghanistan, 
                        Year = 2010, Quarter = Quarter.Q1 
                    };
                case "region":
                    return new SalesQueryParameters { 
                        Region = Region.Asia, 
                        Year = 2010, Quarter = Quarter.Q1 
                    };
                case "countryAndRegion":
                    return new SalesQueryParameters {
                        Region = Region.AustraliaAndOceania, 
                        Country = Country.SaintVincentandtheGrenadines,
                        Year = 2010, Quarter = Quarter.Q1
                    };

                case "empty":
                default:
                    return new SalesQueryParameters();
            }
        }

        [Theory]
        [InlineData("empty", true, typeof(EmptyClause))]
        [InlineData("period", false, typeof(WhereByQuarter))]
        [InlineData("date", false, typeof(WhereDateRange))]
        [InlineData("periodAndDate", false, typeof(WhereDateRange))]
        [InlineData("noPeriodOrDate", true, typeof(WhereCountryIs))]

        [InlineData("country", false, typeof(WhereCountryIs))]
        [InlineData("region", false, typeof(WhereRegionIs))]
        [InlineData("countryAndRegion", false, typeof(WhereCountryIs))]

        public void SalesWhereClauseCompilesCorrectly(string testCaseName, bool shouldThrowException, Type expected)
        {
            var testCase = TestCaseFactory(testCaseName);
            var objectUnderTest = new SalesWhereClause(testCase);
            
            try
            {
                objectUnderTest.Compile();
                Assert.Equal(expected, objectUnderTest.ClauseType);
            }
            catch (NotImplementedException)
            {
                Assert.True(shouldThrowException);
            }
        }

    }
}
