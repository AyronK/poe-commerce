using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronNET.API.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PoECommerce.Client.Electron.Abstraction;
using PoECommerce.Client.Shared.Routing;

namespace PoECommerce.Client.Electron.Tests
{
    public class ElectronWindowManagerTest
    {
        private static ElectronWindowManager _context;
        private static Mock<IElectronApi> _electronApiMock;
        private static Mock<IBrowserWindow> _browserWindowMock;
        private static Mock<INavigationManager> _navigationManagerMock;

        [SetUp]
        public void SetUp()
        {
            With_BrowserWindow();

            _electronApiMock = new Mock<IElectronApi>(MockBehavior.Strict);
            _electronApiMock.Setup(e => e.CreateWindowAsync(It.IsAny<BrowserWindowOptions>(), It.IsAny<string>())).ReturnsAsync(_browserWindowMock.Object);

            _navigationManagerMock = new Mock<INavigationManager>(MockBehavior.Strict);
            _navigationManagerMock.Setup(n => n.ToAbsoluteUri(It.IsAny<string>())).Returns((string s) => new Uri(s));

            _context = new ElectronWindowManager(_electronApiMock.Object, _navigationManagerMock.Object, new List<ElectronWindow>());
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
            ElectronWindow electronWindow = new ElectronWindow(It.IsAny<int>(), It.IsNotNull<BrowserWindowOptions>());

            // When
            _context.AddWindow(electronWindow);

            // Then
            _context.Windows.Should().HaveCount(1);
            _context.Windows.Should().Contain(electronWindow);
            _electronApiMock.Verify(e => e.CreateWindowAsync(It.IsAny<BrowserWindowOptions>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void When_AddWindow_WithDuplicateId()
        {
            // Given
            ElectronWindow electronWindow = new ElectronWindow(1, It.IsNotNull<BrowserWindowOptions>());
            ElectronWindow invalidElectronWindow = new ElectronWindow(1, It.IsNotNull<BrowserWindowOptions>());

            // When
            _context.AddWindow(electronWindow);
            Action when = () => _context.AddWindow(invalidElectronWindow);

            // Then
            when.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task When_LoadUrl()
        {
            // Given
            const string url = "http://www.customsite.com/";
            int id = With_AnyElectronWindow();

            // When
            await _context.LoadUrl(id, url);

            // Then
            _browserWindowMock.Verify(b => b.LoadURL(url), Times.Once);
        }

        [Test]
        public void When_LoadUrl_And_WindowIsNotAdded()
        {
            // When
            Func<Task> when = () => _context.LoadUrl(It.IsAny<int>(), It.IsAny<string>());

            // Then
            when.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task When_Show()
        {
            // Given
            int id = With_AnyElectronWindow();

            // When
            await _context.Show(id);

            // Then
            _browserWindowMock.Verify(b => b.Show(), Times.Once);
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
            // Given
            int id = With_AnyElectronWindow();

            // When
            await _context.Hide(id);

            // Then
            _browserWindowMock.Verify(b => b.Hide(), Times.Once);
        }

        [Test]
        public void When_Hide_And_WindowIsNotAdded()
        {
            // When
            Func<Task> when = () => _context.Hide(It.IsAny<int>());

            // Then
            when.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task When_Close()
        {
            // Given
            int id = With_AnyElectronWindow();

            // When
            await _context.Close(id);

            // Then
            _browserWindowMock.Verify(b => b.Close(), Times.Once);
        }

        [Test]
        public void When_Close_And_WindowIsNotAdded()
        {
            // When
            Func<Task> when = () => _context.Close(It.IsAny<int>());

            // Then
            when.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task When_Minimize()
        {
            // Given
            int id = With_AnyElectronWindow();

            // When
            await _context.Minimize(id);

            // Then
            _browserWindowMock.Verify(b => b.Minimize(), Times.Once);
        }

        [Test]
        public void When_Minimize_And_WindowIsNotAdded()
        {
            // When
            Func<Task> when = () => _context.Minimize(It.IsAny<int>());

            // Then
            when.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task When_Maximize()
        {
            // Given
            int id = With_AnyElectronWindow();

            // When
            await _context.Maximize(id);

            // Then
            _browserWindowMock.Verify(b => b.Maximize(), Times.Once);
        }

        [Test]
        public void When_Maximize_And_WindowIsNotAdded()
        {
            // When
            Func<Task> when = () => _context.Maximize(It.IsAny<int>());

            // Then
            when.Should().Throw<ArgumentException>();
        }

        private static void With_BrowserWindow()
        {
            _browserWindowMock = new Mock<IBrowserWindow>(MockBehavior.Strict);
            _browserWindowMock.Setup(b => b.Show());
            _browserWindowMock.Setup(b => b.Close());
            _browserWindowMock.Setup(b => b.Maximize());
            _browserWindowMock.Setup(b => b.Minimize());
            _browserWindowMock.Setup(b => b.Hide());
            _browserWindowMock.Setup(b => b.LoadURL(It.IsAny<string>()));
        }

        private static int With_AnyElectronWindow()
        {
            const int id = 1;

            ElectronWindow electronWindow = new ElectronWindow(id, It.IsNotNull<BrowserWindowOptions>());
            _context.AddWindow(electronWindow);
            return id;
        }
    }
}
