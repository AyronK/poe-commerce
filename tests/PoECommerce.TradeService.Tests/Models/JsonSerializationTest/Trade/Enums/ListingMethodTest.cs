using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Trade.Enums;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade.Enums
{
    [TestFixture]
    public class ListingMethodTest
    {
        [TestCase(ListingMethod.Forum, "forum")]
        [TestCase(ListingMethod.PremiumStashTab, "psapi")]
        public void When_SerializeToJson(ListingMethod value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<ListingMethod>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("forum", ListingMethod.Forum)]
        [TestCase("psapi", ListingMethod.PremiumStashTab)]
        public void When_DeserializeFromJson(string value, ListingMethod expectedResult)
        {
            // When
            ListingMethod result = JsonSerializer.Deserialize<ListingMethod>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<ListingMethod>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}