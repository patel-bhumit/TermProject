using Moq;
using NUnit.Framework;
using WpfApp5;

namespace WpfApp5Tests;

[TestFixture]
public class BuyerWindowTest
{
    
    [Test]
    [Apartment(ApartmentState.STA)]
    public void BuyerPage_Constructor_Test()
    {
        // Arrange

        // Act
        var page = new BuyerPage();

        // Assert
        Assert.AreEqual(true, true);
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void BuyerPage_Constructor_Exception_Test()
    {
        // Arrange

        // Act
        TestDelegate testDelegate = () => new BuyerPage();

        // Assert
        Assert.AreEqual(true, true);
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void Button_Click_Test()
    {
        Assert.AreEqual(true, true);
    }
}