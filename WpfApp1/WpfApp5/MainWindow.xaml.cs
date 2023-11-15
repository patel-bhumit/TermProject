using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        void Login_Click(object sender, RoutedEventArgs e)
        {
            // get username and password from the textboxes
            string username = Username.Text;
            string password = Password.Password;
            

            // check if the username and password are correct
            if (DataLayer.Model.login.GetRole(username, password) == "admin")
            {
                AdminWindow adminWindow1 = new AdminWindow();
                adminWindow1.Show();  // Show the AdminPage
                this.Close();      // Close the current login window if needed
            }
            else if (DataLayer.Model.login.GetRole(username, password) == "buyer")
            {
                // if they are not, show an error message
                BuyerPage buyerPage1 = new BuyerPage();
                buyerPage1.Show();  // Show the buyerPage
                this.Close();      // Close the current login window if needed

            }

            else
            {
                // if they are not, show an error message
                MessageBox.Show("Invalid username or password");
            }
            
        }
    }
}
