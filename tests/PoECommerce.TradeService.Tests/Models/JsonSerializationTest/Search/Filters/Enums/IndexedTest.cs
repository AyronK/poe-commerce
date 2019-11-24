using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Enums
{
    [TestFixture]
    public class IndexedTest
    {
        [TestCase(Indexed.OneDay, "1day")]
        [TestCase(Indexed.ThreeDays, "3days")]
        [TestCase(Indexed.OneWeek, "1week")]
        [TestCase(Indexed.TwoWeek, "2weeks")]
        [TestCase(Indexed.OneMonth, "1month")]
        [TestCase(Indexed.TwoMonths, "2months")]
        public void When_SerializeToJson(Indexed value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<Indexed>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("1day", Indexed.OneDay)]
        [TestCase("3days", Indexed.ThreeDays)]
        [TestCase("1week", Indexed.OneWeek)]
        [TestCase("2weeks", Indexed.TwoWeek)]
        [TestCase("1month", Indexed.OneMonth)]
        [TestCase("2months", Indexed.TwoMonths)]
        public void When_DeserializeFromJson(string value, Indexed expectedResult)
        {
            // When
            Indexed result = JsonSerializer.Deserialize<Indexed>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<Indexed>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}