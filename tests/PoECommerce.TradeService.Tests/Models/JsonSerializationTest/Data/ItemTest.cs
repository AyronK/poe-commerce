using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Data.Enums;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Data
{
    [TestFixture]
    public class ItemTest
    {
        public static ModelFromJsonTestCase<Item>[] TestCases =
        {
            new ModelFromJsonTestCase<Item>
            {
                Json = "{}",
                ExpectedResult =
                    new Item
                    {
                        Name = null,
                        Type = null,
                        Text = null,
                        Discriminator = null,
                        Flags = null
                    },
                Description = "All nulls"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"name\":\"testName\",\"type\":\"testType\",\"text\":\"testText\",\"disc\":\"testDisc\",\"flags\":null}",
                ExpectedResult =
                    new Item
                    {
                        Name = "testName",
                        Type = "testType",
                        Text = "testText",
                        Discriminator = "testDisc",
                        Flags = null
                    },
                Description = "Without flags"
            },
            new ModelFromJsonTestCase<Item>
            {
                Json = "{\"name\":\"testName\",\"type\":\"testType\",\"text\":\"testText\",\"disc\":\"testDisc\",\"flags\":{\"prophecy\":true,\"unique\":true}}",
                ExpectedResult =
                    new Item
                    {
                        Name = "testName",
                        Type = "testType",
                        Text = "testText",
                        Discriminator = "testDisc",
                        Flags = new Dictionary<ItemFlag, bool>
                        {
                            {ItemFlag.Prophecy, true},
                            {ItemFlag.Unique, true}
                        }
                    },
                Description = "With flags"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Item> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Item result = JsonSerializer.Deserialize<Item>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}