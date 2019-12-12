using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters.Enums
{
    [TestFixture]
    public class SortTypeTest
    {
        [TestCase(SortType.Ascending, "asc")]
        [TestCase(SortType.Descending, "desc")]
        public void When_SerializeToJson(SortType value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<SortType>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("desc", SortType.Descending)]
        [TestCase("asc", SortType.Ascending)]
        public void When_DeserializeFromJson(string value, SortType expectedResult)
        {
            // When
            SortType result = JsonSerializer.Deserialize<SortType>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<SortType>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}