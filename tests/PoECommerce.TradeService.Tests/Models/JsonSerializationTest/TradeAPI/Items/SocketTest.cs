using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;
using PoECommerce.TradeService.Models.TradeAPI.Items;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI.Items
{
    [TestFixture]
    public class SocketTest
    {
        public static ModelFromJsonTestCase<Socket>[] TestCases =
        {
            new ModelFromJsonTestCase<Socket>
            {
                Json = "{\"group\":1,\"attr\":\"D\",\"sColour\":\"G\"}",
                ExpectedResult =
                    new Socket
                    {
                        Group = 1,
                        Attribute = Attribute.Dexterity,
                        Colour = SocketColour.Green
                    }
            },
            new ModelFromJsonTestCase<Socket>
            {
                Json = "{\"group\":2,\"attr\":\"S\",\"sColour\":\"R\"}",
                ExpectedResult =
                    new Socket
                    {
                        Group = 2,
                        Attribute = Attribute.Strength,
                        Colour = SocketColour.Red
                    }
            },
            new ModelFromJsonTestCase<Socket>
            {
                Json = "{\"group\":3,\"attr\":null,\"sColour\":\"A\"}",
                ExpectedResult =
                    new Socket
                    {
                        Group = 3,
                        Attribute = null,
                        Colour = SocketColour.Abyss
                    }
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Socket> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Socket result = JsonSerializer.Deserialize<Socket>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}