using FluentAssertions;
using NUnit.Framework;

namespace PoECommerce.Client.WebBrowser.Tests
{
    public class WebBrowserWindowTest
    {
        [Test]
        public void When_ConstructorWithDefaultLoadUrl()
        {
            // Given
            int id = GetHashCode();

            // When
            WebBrowserWindow result = new WebBrowserWindow(id);

            // Then
            result.Id.Should().Be(id);
            result.LoadPath.Should().BeNullOrEmpty();
            result.IsLoaded.Should().BeFalse();
            result.IsMaximized.Should().BeFalse();
            result.IsOpen.Should().BeFalse();
        }

        [Test]
        public void When_ConstructorWithLoadUrl()
        {
            // Given
            int id = GetHashCode();
            const string loadUrl = "https://custompage.com";

            // When
            WebBrowserWindow result = new WebBrowserWindow(id, loadUrl);

            // Then
            result.Id.Should().Be(id);
            result.LoadPath.Should().Be(loadUrl);
            result.IsLoaded.Should().BeFalse();
            result.IsMaximized.Should().BeFalse();
            result.IsOpen.Should().BeFalse();
        }
    }
}