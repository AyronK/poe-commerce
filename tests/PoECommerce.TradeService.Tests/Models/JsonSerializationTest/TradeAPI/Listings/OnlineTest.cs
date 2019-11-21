﻿using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.TradeAPI.Listings;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI.Listings
{
    [TestFixture]
    public class OnlineTest
    {
        public static ModelFromJsonTestCase<Online>[] TestCases =
        {
            new ModelFromJsonTestCase<Online>
            {
                Json = "{\"league\":null,\"status\":null}",
                ExpectedResult =
                    new Online
                    {
                        League = null,
                        Status = null
                    },
                Description = "All is empty"
            },
            new ModelFromJsonTestCase<Online>
            {
                Json = "{\"league\":\"Delve\",\"status\":\"afk\"}",
                ExpectedResult =
                    new Online
                    {
                        League = "Delve",
                        Status = "afk"
                    }
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Online> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Online result = JsonSerializer.Deserialize<Online>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}