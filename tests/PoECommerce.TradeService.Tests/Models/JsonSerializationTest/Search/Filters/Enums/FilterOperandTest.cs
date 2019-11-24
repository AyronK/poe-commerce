using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters.Enums
{
    [TestFixture]
    public class FilterOperandTest
    {
        [TestCase(FilterOperand.And, "and")]
        [TestCase(FilterOperand.Count, "count")]
        [TestCase(FilterOperand.If, "if")]
        [TestCase(FilterOperand.Not, "not")]
        [TestCase(FilterOperand.Weight, "weight")]
        public void When_SerializeToJson(FilterOperand value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<FilterOperand>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("and", FilterOperand.And)]
        [TestCase("count", FilterOperand.Count)]
        [TestCase("if", FilterOperand.If)]
        [TestCase("not", FilterOperand.Not)]
        [TestCase("weight", FilterOperand.Weight)]
        public void When_DeserializeFromJson(string value, FilterOperand expectedResult)
        {
            // When
            FilterOperand result = JsonSerializer.Deserialize<FilterOperand>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<FilterOperand>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}