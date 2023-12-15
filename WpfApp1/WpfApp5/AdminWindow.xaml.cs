using DataLayer.Context;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using DataLayer.Model;
using MySqlConnector;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Collections.Generic;


namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private int Cid;
        private int ftla;
        private int ltal;
        private double FTLr;
        private double LTLr;
        private double ReefCharge;
        private string newIpAddress;
        private int newPort;

        public AdminWindow()
        {
            InitializeComponent();

            DisplayLogContent();

            try
            {
                using (var TMSContext = new TMSDBContext())
                {
                    CarrierGrid.ItemsSource = TMSContext.Carrier.ToList();
                    RouteGrid.ItemsSource = TMSContext.Route.ToList();  
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            ipAddressTextBox.Text = "127.0.0.1"; // Set default IP address
            portTextBox.Text = "8080"; // Set default port
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string cName = CarrierName.Text;
            string DestinationCity = dCity.Text;
            int.TryParse(FTLA.Text, out ftla);
            int.TryParse(LTLA.Text, out ltal);
            double.TryParse(FTLRate.Text, out FTLr);
            double.TryParse(LTLRate.Text, out LTLr);
            double.TryParse(reefCharge.Text, out ReefCharge);

            try
            {
                using (var context = new TMSDBContext())
                {
                    // Check if the city already exists
                    var existingCity = context.City.SingleOrDefault(c => c.Name == DestinationCity);

                    if (existingCity == null)
                    {
                        // City doesn't exist, create a new one
                        existingCity = new City { Name = DestinationCity };
                        context.City.Add(existingCity);
                        context.SaveChanges(); // Save changes to get the CityId
                    }

                    var carrier = new DataLayer.Model.Carrier
                    {
                        cName = cName,
                        dCity = DestinationCity,
                        FTLA = ftla,
                        LTLA = ltal,
                        FTLARate = FTLr,
                        LTLRate = LTLr,
                        reefCharge = ReefCharge,
                        CityId = existingCity.CityId // Assign the CityId
                    };

                    context.Carrier.Add(carrier);
                    context.SaveChanges();

                    // Create a new Route associated with the added carrier
                    var route = new Route
                    {
                        cID = carrier.cID,  // Replace with the actual origin
                        CarrierName = cName,
                        DestinationCity = DestinationCity
                    };

                    context.Route.Add(route);
                    context.SaveChanges();

                    CarrierGrid.ItemsSource = context.Carrier.ToList();

                    LogEntry logEntry = new LogEntry
                    {
                        LogLevel = "Info",
                        Message = $"Carrier added - {cName}",
                        Timestamp = DateTime.Now
                    };
                    context.LogEntries.Add(logEntry);
                    context.SaveChanges();

                    // Refresh logs
                    DisplayLogContent();
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception details, including inner exception
                var message = $"Error: {ex.Message}";

                if (ex.InnerException != null)
                {
                    message += $"\nInner Exception: {ex.InnerException.Message}";
                }

                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveChangesRouteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new TMSDBContext())
                {
                    // Get the list of items bound to the DataGrid
                    var routes = RouteGrid.ItemsSource as List<Route>;

                    if (routes != null)
                    {
                        foreach (var route in routes)
                        {
                            // Attach the route
                            context.Attach(route);

                            // Explicitly set the state for the route entity
                            context.Entry(route).State = EntityState.Modified;

                            // Exclude certain properties from modification
                            if (context.Entry(route).Property("CarrierName").IsModified == true || context.Entry(route).Property("cID").IsModified == true || context.Entry(route).Property("RouteID").IsModified == true)
                            {
                                context.Entry(route).Property("RouteID").IsModified = false;
                                context.Entry(route).Property("CarrierName").IsModified = false;
                                context.Entry(route).Property("cID").IsModified = false;

                                MessageBox.Show("Carrier name and CarrierID and RouteID cannot be modified.");
                                RefreshRoute_Click(sender, e);
                                return;
                            }

                            // If the DestinationCity property is modified, update the CityId
                            if (context.Entry(route).Property("DestinationCity").IsModified)
                            {
                                // Fetch the corresponding City entity from the database
                                var city = context.City.SingleOrDefault(c => c.Name == route.DestinationCity);
                            }
                        }

                        // Save changes to the database
                        context.SaveChanges();

                        MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }



        private void Delete_Click(object sender, EventArgs e)
        {
            int.TryParse(CarrierID.Text, out Cid);

            using (var context = new TMSDBContext())
            {
                var carrier = context.Carrier
                    .Where(c => c.cID == Cid)
                    .FirstOrDefault();

                if (carrier != null)
                {
                    // Delete associated routes
                    var routesToDelete = context.Route.Where(r => r.cID == Cid);
                    context.Route.RemoveRange(routesToDelete);

                    context.Carrier.Remove(carrier);
                    context.SaveChanges();

                    CarrierGrid.ItemsSource = context.Carrier.ToList();
                }
                else
                {
                    MessageBox.Show("Carrier not found");
                }

                // Log the carrier deletion
                LogEntry logEntry = new LogEntry
                {
                    LogLevel = "Info",
                    Message = $"Carrier deleted - Carrier ID: {Cid}",
                    Timestamp = DateTime.Now
                };
                context.LogEntries.Add(logEntry);
                context.SaveChanges();

                // Refresh logs
                DisplayLogContent();
            }
        }


        private void DisplayLogContent()
        {
            try
            {
                using (var TMSContext = new TMSDBContext())
                {
                    // Assuming LogEntries is your DbSet for logs in TMSDBContext
                    var logEntries = TMSContext.LogEntries.ToList();

                    // Concatenate log entries into a single string
                    string logContent = string.Join("\n", logEntries.Select(log => log.Message));

                    // Set log content to the LogTextBox
                    LogTextBox.Text = logContent;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex, "Error viewing log file");
            }
        }

        private void ShowErrorMessageBox(Exception ex, string message)
        {
            // Handle and display errors
            MessageBox.Show($"{message}\n\nError: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void DownloadLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open a file dialog to select the download location
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Log Files (*.log)|*.log",
                    Title = "Save Log File",
                    FileName = "log_file.log"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    using (var TMSContext = new TMSDBContext())
                    {
                        // Assuming LogEntries is your DbSet for logs in TMSDBContext
                        var logEntries = TMSContext.LogEntries.ToList();

                        // Concatenate log entries into a single string
                        string logContent = string.Join("\n", logEntries.Select(log => log.Message));

                        // Save the log content to the selected file
                        File.WriteAllText(saveFileDialog.FileName, logContent);
                        MessageBox.Show("Log file downloaded successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex, "Error downloading log file");
            }
        }

        private void ApplyIPPortChanges_Click(object sender, RoutedEventArgs e)
        {
            // Get the new IP address and port from the TextBoxes
            newIpAddress = ipAddressTextBox.Text;

            // Validate and parse port
            if (int.TryParse(portTextBox.Text, out int port))
            {
                newPort = port;

                // Apply the changes (e.g., update database, configuration, etc.)
                ApplyIPPortChanges(newIpAddress, newPort);

                MessageBox.Show("IP and Port changes applied successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid port number. Please enter a valid integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyIPPortChanges(string ipAddress, int port)
        {
            try
            {
                // Update the IP address and port in your application
                // For example, you might store them in a configuration file or database
                // Here, we're just logging the changes as an example
                LogEvent("INFO", $"IP and Port changed to {ipAddress}:{port}    - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            }
            catch (Exception ex)
            {
                // Handle and log the error
                ShowErrorMessageBox(ex, "Error applying IP and Port changes");
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

        private void BackupDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the directory where the user wants to save the backup
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Backup Files (*.bak)|*.bak",
                    Title = "Backup Database",
                    FileName = "database_backup.bak"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    string backupFilePath = saveFileDialog.FileName;

                    // Specify the full path of the mysqldump utility
                    string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe";

                    // Specify the MySQL connection string
                    string connectionString = "server=localhost;port=3306;database=TMS;user=root;password=9487;";

                    // Parse the connection string to get the user name, password, and database name
                    var builder = new MySqlConnectionStringBuilder(connectionString);
                    string user = builder.UserID;
                    string password = builder.Password;
                    string database = builder.Database;

                    // Create the backup command
                    string backupCommand = $"{mysqldumpPath} -u {user} -p{password} {database}";

                    // Start the backup process
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = mysqldumpPath,
                        Arguments = $"-u {user} -p{password} {database}",
                        RedirectStandardInput = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = Path.GetDirectoryName(mysqldumpPath)
                    };

                    using (Process process = new Process { StartInfo = psi })
                    {
                        process.Start();

                        // Read the output and error streams
                        string output = process.StandardOutput.ReadToEnd();
                        string errors = process.StandardError.ReadToEnd();

                        // Wait for the process to finish
                        process.WaitForExit();

                        if (process.ExitCode == 0)
                        {
                            // Save the output to the backup file
                            File.WriteAllText(backupFilePath, output);

                            Console.WriteLine("Database backup successful!");
                            MessageBox.Show("Database backup successful!", "Backup Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            Console.WriteLine($"Error during database backup: {errors}");
                            MessageBox.Show($"Error during database backup:\n{errors}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex, "Error during database backup");
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new TMSDBContext())
                {
                    // Get the list of items bound to the DataGrid
                    var carriers = CarrierGrid.ItemsSource as List<Carrier>;

                    if (carriers != null)
                    {
                        foreach (var carrier in carriers)
                        {
                            // Attach the carrier
                            context.Attach(carrier);

                            // Explicitly set the state for the carrier entity
                            context.Entry(carrier).State = EntityState.Modified;

                            // Exclude certain properties from modification
                            if (context.Entry(carrier).Property("cName").IsModified == true ||
                                context.Entry(carrier).Property("dCity").IsModified == true ||
                                context.Entry(carrier).Property("CityId").IsModified == true)
                            {

                                context.Entry(carrier).Property("cName").IsModified = false;
                                context.Entry(carrier).Property("dCity").IsModified = false;
                                context.Entry(carrier).Property("CityId").IsModified = false;

                                MessageBox.Show("Carrier name and destination city cannot be modified.");
                                Refresh_Click(sender, e);
                                return;
                            }

                            // If the dCity property is modified, update the CityId
                            if (context.Entry(carrier).Property("dCity").IsModified)
                            {
                                // Fetch the corresponding City entity from the database
                                var city = context.City.SingleOrDefault(c => c.Name == carrier.dCity);

                                if (city != null)
                                {
                                    // Update the CityId property in the Carrier entity
                                    carrier.CityId = city.CityId;
                                }
                                else
                                {
                                    // Handle the case where the city is not found
                                    MessageBox.Show($"City '{carrier.dCity}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return; // Skip saving changes if the city is not found
                                }
                            }
                        }

                        // Save changes to the database
                        context.SaveChanges();

                        MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (var TMSContext = new TMSDBContext())
            {
                CarrierGrid.ItemsSource = null;
                CarrierGrid.ItemsSource = TMSContext.Carrier.ToList();
            }
        }

        private void RefreshRoute_Click(object sender, RoutedEventArgs e)
        {
            using (var TMSContext = new TMSDBContext())
            {
                RouteGrid.ItemsSource = null;
                RouteGrid.ItemsSource = TMSContext.Route.ToList();
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window and open the MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
