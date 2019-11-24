using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Enums
{
    [TestFixture]
    public class OnlineStatusTest
    {
        [TestCase(OnlineStatus.Online, "online")]
        public void When_SerializeToJson(OnlineStatus value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<OnlineStatus>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("online", OnlineStatus.Online)]
        public void When_DeserializeFromJson(string value, OnlineStatus expectedResult)
        {
            // When
            OnlineStatus result = JsonSerializer.Deserialize<OnlineStatus>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<OnlineStatus>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}