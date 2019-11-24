using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search.Filters.Wrappers
{
    [TestFixture]
    public class StringOptionTest
    {
        public static ModelToJsonTestCase<StringOption>[] TestCases =
        {
            new ModelToJsonTestCase<StringOption>
            {
                Subject = new StringOption {Value = null},
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<StringOption>
            {
                Subject = new StringOption {Value = "test"},
                ExpectedJson = "{\"option\":\"test\"}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<StringOption> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}