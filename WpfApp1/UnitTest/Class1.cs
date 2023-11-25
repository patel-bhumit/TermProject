using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static WpfApp5.MainWindow;
using WpfApp5;
using DataLayer.Model;
using System.Windows;

namespace UnitTest
{
    public class Class1
    {
        [TestFixture]
        public class LoginTests
        {
            private MainWindow? _window;
            private AdminWindow? _adminWindow;
            private BuyerPage? _buyerPage;

            [SetUp]
            public void Setup()
            {
                _window = new MainWindow();
            }

            [Test]
            public void Login_Click_WithAdminCredentials_ShowsAdminWindow()
            {
                _window.SetUsername("admin");
                _window.SetPassword("admin");

                _window.Login_Click(null, null);

                // Assuming you have a way to check if the AdminWindow is visible
                Assert.IsTrue(_window.IsAdminWindowVisible);
                Assert.IsFalse(_window.IsVisible);
            }


        }

    }
}
