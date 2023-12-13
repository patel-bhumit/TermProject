using System.Windows;
using DataLayer.Model;

namespace WpfApp5;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ILogin _login;

    public MainWindow()
    {
        InitializeComponent();
        _login = new Login();
    }

    public void SetLogin(ILogin login)
    {
        _login  = login;
    }

    public bool IsAdminWindowVisible { get; private set; }

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

    public void Login_Click(object sender, RoutedEventArgs e)
    {
        // get username and password from the textboxes
        var username = Username.Text;
        var password = Password.Password;
        
        var role = _login.GetRole(username, password);

        // check if the username and password are correct
        if (role == "admin")
        {
            var adminWindow1 = new AdminWindow();
            adminWindow1.Show(); // Show the AdminPage
            Close(); // Close the current Login window if needed
        }
        else if (role == "buyer")
        {
            // if they are not, show an error message
            var buyerPage1 = new BuyerPage();
            buyerPage1.Show(); // Show the buyerPage
            Close(); // Close the current Login window if needed
            IsAdminWindowVisible = true;
        }

        else
        {
            // if they are not, show an error message
            MessageBox.Show("Invalid username or password");
        }
    }
}