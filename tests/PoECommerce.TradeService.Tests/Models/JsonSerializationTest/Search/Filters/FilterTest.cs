using System.Text.Encodings.Web;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters
{
    [TestFixture]
    public class FilterTest
    {
        public static ModelToJsonTestCase<Filter>[] TestCases =
        {
            new ModelToJsonTestCase<Filter>
            {
                Subject = new Filter
                {
                    TypeFilter = null,
                    WeaponFilter = null,
                    ArmourFilter = null,
                    SocketFilter = null,
                    RequirementsFilter = null,
                    MiscellaneousFilter = null,
                    MapsFilter = null,
                    TradeFilter = null
                },
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<Filter>
            {
                Subject = new Filter
                {
                    TypeFilter = new FilterWrapper<TypeFilter>
                    {
                        Filter = new TypeFilter()
                    },
                    WeaponFilter = new FilterWrapper<WeaponsFilter>
                    {
                        Filter = new WeaponsFilter()
                    },
                    ArmourFilter = new FilterWrapper<ArmoursFilter>
                    {
                        Filter = new ArmoursFilter()
                    },
                    SocketFilter = new FilterWrapper<SocketsGroupFilter>
                    {
                        Filter = new SocketsGroupFilter()
                    },
                    RequirementsFilter = new FilterWrapper<RequirementsFilter>
                    {
                        Filter = new RequirementsFilter()
                    },
                    MiscellaneousFilter = new FilterWrapper<MiscellaneousFilter>
                    {
                        Filter = new MiscellaneousFilter()
                    },
                    MapsFilter = new FilterWrapper<MapsFilter>
                    {
                        Filter = new MapsFilter()
                    },
                    TradeFilter = new FilterWrapper<TradeFilter>
                    {
                        Filter = new TradeFilter()
                    }
                },
                ExpectedJson = "{\"type_filters\":{\"filters\":{}},\"weapon_filters\":{\"filters\":{}},\"armour_filters\":{\"filters\":{}},\"socket_filters\":{\"filters\":{}},\"req_filters\":{\"filters\":{}},\"misc_filters\":{\"filters\":{}},\"map_filters\":{\"filters\":{}},\"trade_filters\":{\"filters\":{}}}"
            }
        };


        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<Filter> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}