﻿using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Wrappers
{
    [TestFixture]
    public class IndexedOptionTest
    {
        public static ModelToJsonTestCase<IndexedOption>[] TestCases =
        {
            new ModelToJsonTestCase<IndexedOption>
            {
                Subject = new IndexedOption {Value = null},
                ExpectedJson = "{}",
                Description = "Null"
            },
            new ModelToJsonTestCase<IndexedOption>
            {
                Subject = new IndexedOption {Value = Indexed.OneMonth},
                ExpectedJson = "{\"option\":\"1month\"}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<IndexedOption> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}