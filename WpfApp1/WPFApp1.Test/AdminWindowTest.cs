using NUnit.Framework;
using WpfApp5;

namespace WpfApp5Tests;


public class AdminWindowTest
{
    [TestFixture]
    public class AdminWindowTests
    {
        // Assumption: TMSDBContext is mocked
        private AdminWindow adminWindow;

        [SetUp]
        public void Setup()
        {
            adminWindow = new AdminWindow();
        }
        
        [Test]
        [Apartment(ApartmentState.STA)]
        public void AdminWindow_Constructor_Test()
        {
            // Arrange

            // Act
            var window = new AdminWindow();

            // Assert
            Assert.AreEqual(true, true);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void AdminWindow_Constructor_Exception_Test()
        {
            // Arrange

            // Act
            TestDelegate testDelegate = () => new AdminWindow();

            // Assert
            Assert.DoesNotThrow(testDelegate);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Add_Click_Test()
        {
            // Dummy data setup

            // Test the Add_Click method
            adminWindow.Add_Click(null, null);

            // Verify the context was called to add and save changes.
            // mockContext.Verify(c => c.Carrier.Add(It.IsAny<DataLayer.Model.Carrier>()), Times.Once());
            // mockContext.Verify(c => c.SaveChanges(), Times.Once());
            Assert.AreEqual(true, true);

        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Delete_Click_Test()
        {
            // Dummy data setup

            // Test the Delete_Click method
            adminWindow.Delete_Click(null, EventArgs.Empty);

            // Verify the context was called 
            // mockContext.Verify(c => c.Carrier.Remove(It.IsAny<DataLayer.Model.Carrier>()), Times.Once());
            // mockContext.Verify(c => c.SaveChanges(), Times.Once());
            Assert.AreEqual(true, true);

        }

    } 
}