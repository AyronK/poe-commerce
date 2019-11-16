using System.Threading.Tasks;
using ElectronNET.API.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PoECommerce.Client.Electron.Abstraction;

namespace PoECommerce.Client.Electron.Tests
{
    public class ElectronWindowTest
    {
        [Test]
        public void When_ConstructorWithDefaultLoadUrl()
        {
            // Given
            int id = GetHashCode();
            BrowserWindowOptions options = new BrowserWindowOptions();
            
            // When
            ElectronWindow result = new ElectronWindow(id, options);

            // Then
            result.Id.Should().Be(id);
            result.WindowOptions.Should().Be(options);
            result.LoadPath.Should().BeNullOrEmpty();
            result.IsLoaded.Should().BeFalse();
            result.IsMaximized.Should().BeFalse();
            result.IsOpen.Should().BeFalse();
            result.BrowserWindow.Should().BeNull("because it is not yet initialized");
        }

        [Test]
        public void When_ConstructorWithLoadUrl()
        {
            // Given
            int id = GetHashCode();
            BrowserWindowOptions options = new BrowserWindowOptions();
            const string loadUrl = "https://custompage.com";
            
            // When
            ElectronWindow result = new ElectronWindow(id, options, loadUrl);

            // Then
            result.Id.Should().Be(id);
            result.WindowOptions.Should().Be(options);
            result.LoadPath.Should().Be(loadUrl);
            result.IsLoaded.Should().BeFalse();
            result.IsMaximized.Should().BeFalse();
            result.IsOpen.Should().BeFalse();
            result.BrowserWindow.Should().BeNull("because it is not yet initialized");
        }

        [Test]
        public async Task When_Initialize()
        {
            // Given
            IBrowserWindow browserWindow = Mock.Of<IBrowserWindow>();
            ElectronWindow window = new ElectronWindow(It.IsAny<int>(), It.IsAny<BrowserWindowOptions>());

            // When
            await window.InitializeWindow(() => Task.FromResult(browserWindow));

            // Then
            window.BrowserWindow.Should().NotBeNull();
            window.BrowserWindow.Should().Be(browserWindow);
        }
    }
}