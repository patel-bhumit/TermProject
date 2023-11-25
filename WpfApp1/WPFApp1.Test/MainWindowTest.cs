using NUnit.Framework;
using WpfApp5;
using Moq;

namespace WPFApp1.Test
{
    [TestFixture]
    public class MainWindowTests
    {
        [Test]
        public void Login_Click_AdminRole_ShouldOpenAdminWindow()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var mockLogin = new Mock<ILogin>();
            mockLogin.Setup(x => x.GetRole(It.IsAny<string>(), It.IsAny<string>())).Returns("admin");
            DataLayer.Model.login = mockLogin.Object;

            // Act
            mainWindow.Login_Click(null, null);

            // Assert
            Assert.IsTrue(mainWindow.IsClosed);  // Replace with the correct property or method
            // Add more assertions if needed
        }

        // Other tests...

        // Define the ILogin interface or use the actual type representing login functionality
        public interface ILogin
        {
            string GetRole(string username, string password);
        }
    }

}

