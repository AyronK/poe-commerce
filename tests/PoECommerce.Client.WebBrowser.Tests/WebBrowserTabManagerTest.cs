using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.JSInterop;
using Moq;
using NUnit.Framework;
using PoECommerce.Client.Shared.Routing;

namespace PoECommerce.Client.WebBrowser.Tests
{
    public class WebBrowserTabManagerTest
    {
        private static WebBrowserTabManager _context;
        private static Mock<IJSRuntime> _jsRuntimeMock;
        private static Mock<INavigationManager> _navigationManagerMock;

        [SetUp]
        public void SetUp()
        {
            _jsRuntimeMock = new Mock<IJSRuntime>(MockBehavior.Strict);
            _jsRuntimeMock.Setup(e => e.InvokeAsync<object>(It.IsAny<string>(), It.IsAny<object[]>())).Returns(new ValueTask<object>());

            _navigationManagerMock = new Mock<INavigationManager>(MockBehavior.Strict);
            _navigationManagerMock.Setup(n => n.ToAbsoluteUri(It.IsAny<string>())).Returns((string s) => new Uri(s));

            _context = new WebBrowserTabManager(_jsRuntimeMock.Object, _navigationManagerMock.Object, new List<WebBrowserWindow>());
        }

        [Test]
        public void When_DefaultState()
        {
            // Then
            _context.Windows.Should().BeEmpty();
        }

        [Test]
        public void When_AddWindow()
        {
            // Given
            WebBrowserWindow webBrowserWindow = new WebBrowserWindow(It.IsAny<int>());

            // When
            _context.AddWindow(webBrowserWindow);

            // Then
            _context.Windows.Should().HaveCount(1);
            _context.Windows.Should().Contain(webBrowserWindow);
            _jsRuntimeMock.Verify(e => e.InvokeAsync<object>(It.IsAny<string>(), It.IsAny<object[]>()), Times.Never);
        }

        [Test]
        public void When_AddWindow_WithDuplicateId()
        {
            // Given
            WebBrowserWindow webBrowserWindow = new WebBrowserWindow(1);
            WebBrowserWindow invalidWebBrowserWindow = new WebBrowserWindow(1);

            // When
            _context.AddWindow(webBrowserWindow);
            Action when = () => _context.AddWindow(invalidWebBrowserWindow);

            // Then
            when.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task When_LoadUrl()
        {
            // Given
            const string url = "http://www.customsite.com/";
            WebBrowserWindow window = With_AnyWebBrowserWindow();

            // When
            await _context.LoadUrl(window.Id, url);

            // Then
            _jsRuntimeMock.Verify(e => e.InvokeAsync<object>("open", new object[] { url, "_blank" }), Times.Once);
        }

        [Test]
        public async Task When_Show()
        {
            // Given
            WebBrowserWindow window = With_AnyWebBrowserWindow();

            // When
            await _context.Show(window.Id);

            // Then
            _jsRuntimeMock.Verify(e => e.InvokeAsync<object>("open", new object[] { window.LoadPath, "_blank" }), Times.Once);
        }

        [Test]
        public void When_Show_And_WindowIsNotAdded()
        {
            // When
            Func<Task> when = () => _context.Show(It.IsAny<int>());

            // Then
            when.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task When_Hide()
        {
            WebBrowserWindow window = With_AnyWebBrowserWindow();

            // When
            await _context.Hide(window.Id);

            // Then
            _jsRuntimeMock.Verify(e => e.InvokeAsync<object>(It.IsAny<string>(), It.IsAny<object[]>()), Times.Never);
        }

        [Test]
        public async Task When_Close()
        {
            // Given
            WebBrowserWindow window = With_AnyWebBrowserWindow();

            // When
            await _context.Close(window.Id);

            // Then
            _jsRuntimeMock.Verify(e => e.InvokeAsync<object>(It.IsAny<string>(), It.IsAny<object[]>()), Times.Never);
        }

        [Test]
        public async Task When_Minimize()
        {
            // Given
            WebBrowserWindow window = With_AnyWebBrowserWindow();

            // When
            await _context.Minimize(window.Id);

            // Then
            _jsRuntimeMock.Verify(e => e.InvokeAsync<object>(It.IsAny<string>(), It.IsAny<object[]>()), Times.Never);
        }

        [Test]
        public async Task When_Maximize()
        {
            // Given
            WebBrowserWindow window = With_AnyWebBrowserWindow();

            // When
            await _context.Maximize(window.Id);

            // Then
            _jsRuntimeMock.Verify(e => e.InvokeAsync<object>("open", new object[] { window.LoadPath, "_blank" }), Times.Once);
        }

        [Test]
        public void When_Maximize_And_WindowIsNotAdded()
        {
            // When
            Func<Task> when = () => _context.Maximize(It.IsAny<int>());

            // Then
            when.Should().Throw<ArgumentException>();
        }

        private static WebBrowserWindow With_AnyWebBrowserWindow()
        {
            WebBrowserWindow webBrowserWindow = new WebBrowserWindow(1, "http://custompage.com/");
            _context.AddWindow(webBrowserWindow);
            return webBrowserWindow;
        }
    }
}
