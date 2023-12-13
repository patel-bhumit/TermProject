using System.Windows;

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

        public string GetUsername()
        {
            return Username.Text;
        }

        public void SetUsername(string username)
        {
            Username.Text = username;
        }

        public string GetPassword()
        {
            return Password.Password;
        }

        public void SetPassword(string password)
        {
            Password.Password = password;
        }

        public bool IsAdminWindowVisible { get; private set; }

        public void Login_Click(object sender, RoutedEventArgs e)
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
                IsAdminWindowVisible = true;
            }

            else
            {
                // if they are not, show an error message
                MessageBox.Show("Invalid username or password");
            }
            
        }
    }
}
