using NUnit.Framework;
using WpfApp5;
using Moq; // If mocking is needed
// Other necessary imports

namespace WpfApp5Tests
{
    [TestFixture]
    public class MainWindowTests
    {
        private MainWindow mainWindow;

        [SetUp]
        public void Setup()
        {
            // Initialize the MainWindow object before each test
            mainWindow = new MainWindow();
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
        public void Login_Click_InvalidCredentials_ShowsErrorMessage()
        {
            // This test requires mocking the DataLayer.Model.login dependency
            // Arrange: Set up invalid credentials and mock the login response

            // Act: Call the Login_Click method

            // Assert: Verify that an error message is expected to be shown
        }

        // Additional tests can be written for valid credentials and different user roles
    }
}
