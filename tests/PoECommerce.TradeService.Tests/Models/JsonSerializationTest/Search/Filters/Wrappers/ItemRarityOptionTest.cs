﻿using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Wrappers
{
    [TestFixture]
    public class ItemRarityOptionTest
    {
        public static ModelToJsonTestCase<ItemRarityOption>[] TestCases =
        {
            new ModelToJsonTestCase<ItemRarityOption>
            {
                Subject = new ItemRarityOption {Value = null},
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<ItemRarityOption>
            {
                Subject = new ItemRarityOption {Value = ItemRarity.Magic},
                ExpectedJson = "{\"option\":\"magic\"}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<ItemRarityOption> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}