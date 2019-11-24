using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters.Enums
{
    [TestFixture]
    public class SaleTypeTest
    {
        [TestCase(SaleType.NotPriced, "unpriced")]
        [TestCase(SaleType.Priced, "priced")]
        public void When_SerializeToJson(SaleType value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<SaleType>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("unpriced", SaleType.NotPriced)]
        [TestCase("priced", SaleType.Priced)]
        public void When_DeserializeFromJson(string value, SaleType expectedResult)
        {
            // When
            SaleType result = JsonSerializer.Deserialize<SaleType>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<SaleType>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}