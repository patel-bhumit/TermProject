using DataLayer.Model;
using NUnit.Framework;
using WpfApp5;
using Moq;

namespace WpfApp5Tests
{
    [TestFixture]
    public class MainWindowTests
    {
        private MainWindow mainWindow;
        private Mock<ILogin> mockLogin;

        [SetUp]
        public void Setup()
        {
            mockLogin = new Mock<ILogin>();
            // Initialize the MainWindow object before each test
            mainWindow = new MainWindow();
            mainWindow.SetLogin(mockLogin.Object);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void GetUsername_InitiallyEmpty_ReturnsEmptyString()
        {
            // Arrange is done in Setup

            // Act
            var username = mainWindow.GetUsername();

            // Assert
            Assert.IsEmpty(username);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetUsername_SetToSampleUsername_UsernameIsSet()
        {
            // Arrange
            var sampleUsername = "TestUser";

            // Act
            mainWindow.SetUsername(sampleUsername);
            var username = mainWindow.GetUsername();

            // Assert
            Assert.AreEqual(sampleUsername, username);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void GetPassword_InitiallyEmpty_ReturnsEmptyString()
        {
            // Arrange is done in Setup

            // Act
            var password = mainWindow.GetPassword();

            // Assert
            Assert.IsEmpty(password);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetPassword_SetToSamplePassword_PasswordIsSet()
        {
            // Arrange
            var samplePassword = "TestPassword";

            // Act
            mainWindow.SetPassword(samplePassword);
            var password = mainWindow.GetPassword();

            // Assert
            Assert.AreEqual(samplePassword, password);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Login_Click_AdminCredentials_AdminWindowOpens()
        {
            // Arrange
            mockLogin.Setup(m => m.GetRole(It.IsAny<string>(), It.IsAny<string>())).Returns("admin");
            mainWindow.SetUsername("admin");
            mainWindow.SetPassword("password");
            // Act
            mainWindow.Login_Click(null, null);
            // Assert
            // Here you need to check that the AdminWindow was opened. This might require additional changes to your code to make it testable.
        }
        [Test]
        [Apartment(ApartmentState.STA)]
        public void Login_Click_BuyerCredentials_BuyerPageOpens()
        {
            // Arrange
            mockLogin.Setup(m => m.GetRole(It.IsAny<string>(), It.IsAny<string>())).Returns("buyer");
            mainWindow.SetUsername("buyer");
            mainWindow.SetPassword("password");
            // Act
            mainWindow.Login_Click(null, null);
            // Assert
            // Here you need to check that the BuyerPage was opened. This might require additional changes to your code to make it testable.
        }
        [Test]
        [Apartment(ApartmentState.STA)]
        public void Login_Click_InvalidCredentials_ErrorMessageShown()
        {
            // Arrange
            mockLogin.Setup(m => m.GetRole(It.IsAny<string>(), It.IsAny<string>())).Returns((string)null);
            mainWindow.SetUsername("invalid");
            mainWindow.SetPassword("invalid");
            // Act
            mainWindow.Login_Click(null, null);
            // Assert
            // Here you need to check that an error message was shown. This might require additional changes to your code to make it testable.
        }

    }
}
