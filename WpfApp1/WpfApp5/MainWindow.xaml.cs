using DataLayer.Context;
using System;
using System.Windows;
using DataLayer.Model;

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

                // Check if the username and password are correct
            string role = DataLayer.Model.login.GetRole(username, password);

            if (role != null)
            {
                LogEvent("INFO", $"User '{username}' logged in.   - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                if (role == "admin")
                {
                    AdminWindow adminWindow1 = new AdminWindow();
                    adminWindow1.Show();
                    this.Close();
                }
                else if (role == "buyer")
                {
                    BuyerPage buyerPage1 = new BuyerPage();
                    buyerPage1.Show();
                    this.Close();
                    IsAdminWindowVisible = true;
                }

                else if (role == "planner")
                {
                    PlannerPage plannerPage1 = new PlannerPage();
                    plannerPage1.Show();
                    this.Close();
                    IsAdminWindowVisible = true;
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            else
            {
                // Log failed login attempt
                LogEvent("WARN", $"Failed login attempt for user '{username}'.  - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                MessageBox.Show("Invalid username or password");
            }
        }

        private void LogEvent(string logLevel, string message)
        {
            try
            {
                using (var context = new TMSDBContext())
                {
                    var logEntry = new LogEntry
                    {
                        Timestamp = DateTime.Now,
                        LogLevel = logLevel,
                        Message = message
                    };

                    context.LogEntries.Add(logEntry);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle and log the error
                Console.WriteLine($"Error logging event to database: {ex.Message}    - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            }
        }
    }
}
