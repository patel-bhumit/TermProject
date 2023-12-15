using DataLayer.Context;
using DataLayer.Model.DataLayer.Model;
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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using DataLayer.Model;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for PlannerPage.xaml
    /// </summary>
    public partial class PlannerPage : Window
    {
        public PlannerPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new TMSDBContext())
            {
                OrdersGrid.ItemsSource = null;
                OrdersGrid.ItemsSource = context.Order
                    .Where(o => o.OrderStatus == "Pending")
                    .ToList();


                TripGrid.ItemsSource = null;
                TripGrid.ItemsSource = context.Trip.Where(t => t.OrderStatus == "initiated").ToList();

                CompletedOrderGrid.ItemsSource = null;
                CompletedOrderGrid.ItemsSource = context.Order
                    .Where(o => o.OrderStatus == "completed")
                    .ToList();
            }

        }

        private void LoadOrders()
        {
            try
            {
                using (var context = new TMSDBContext())
                {
                    // Filter orders with a pending status
                    var orders = context.Order
                        .Where(o => o.OrderStatus == "Pending")
                        .ToList();

                    var trips = context.Trip.Where(t => t.OrderStatus == "initiated").ToList();

                    var completedOrder = context.Order
                        .Where(o => o.OrderStatus == "completed")
                        .ToList();

                    OrdersGrid.ItemsSource = orders;
                    TripGrid.ItemsSource = trips;
                    CompletedOrderGrid.ItemsSource = completedOrder;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void AssignCarrier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new TMSDBContext())
                {
                    // Retrieve the selected order
                    Order selectedOrder = GetSelectedOrder();

                    if (selectedOrder != null)
                    {
                        // Retrieve carriers with the same destination as the selected order
                        var carriersWithSameDestination = context.Carrier
                            .Where(c => c.dCity == selectedOrder.Destination)
                            .ToList();

                        if (carriersWithSameDestination.Any())
                        {
                            // Display the CarrierSelectionDialog
                            var carrierSelectionDialog = new CarrierSelectionDialog(carriersWithSameDestination);
                            bool? result = carrierSelectionDialog.ShowDialog();

                            if (result == true && carrierSelectionDialog.SelectedCarrier != null)
                            {
                                try
                                {
                                    // Detach existing tracked Carrier entity if not null
                                    if (selectedOrder.Carrier != null)
                                    {
                                        context.Entry(selectedOrder.Carrier).State = EntityState.Detached;
                                    }

                                    // Load Carrier entity without tracking
                                    var selectedCarrier = context.Carrier.AsNoTracking().FirstOrDefault(c => c.cID == carrierSelectionDialog.SelectedCarrier.cID);

                                    // Check carrier capacity
                                    if (CheckCarrierCapacity(selectedCarrier, selectedOrder.Quantity))
                                    {
                                        // Assign the selectedCarrier to the selectedOrder
                                        selectedOrder.Carrier = null;  // Set to null to ensure a new instance is used
                                        selectedOrder.cID = selectedCarrier.cID;  // Assign the foreign key directly

                                        // Update status to "initiated"
                                        selectedOrder.OrderStatus = "initiated";

                                        // Assign the delivery date with an average 1-day increment from the current date and time
                                        selectedOrder.DeliveryDate = DateTime.Now.AddDays(1);

                                        // Calculate the number of trips based on the quantity (for LTL jobs)
                                        int numberOfTrips = (int)Math.Ceiling((double)selectedOrder.Quantity / selectedCarrier.LTLA);

                                        // Create and assign multiple trips to the order
                                            Trip newTrip = new Trip
                                            {
                                                OrderID = selectedOrder.OrderID,
                                                OrderStatus = selectedOrder.OrderStatus,
                                                TripNumber = numberOfTrips,
                                                ClientName = selectedOrder.ClientName,
                                                CarrierName = selectedCarrier.cName,
                                                CarrierID = selectedCarrier.cID,
                                                AssignDate = DateTime.Now,
                                                DeliveryDate = selectedOrder.DeliveryDate.Value.AddDays(numberOfTrips * 1) // Assuming 1 days between trips
                                            };

                                            context.Trip.Add(newTrip);

                                        // Mark the order as modified using context.Update
                                        context.Update(selectedOrder);

                                        // Save the changes to the database
                                        int result1 = context.SaveChanges();

                                        // Save changes to add Trips to the database
                                        context.SaveChanges();

                                        if (result1 > 0)
                                        {
                                            // Changes were successful
                                            MessageBox.Show("Carrier assigned successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                            LogEvent("Info", $"Carrier assigned for Order ID: {selectedOrder.OrderID}, Carrier ID: {selectedCarrier.cID}");
                                        }
                                        else
                                        {
                                            MessageBox.Show("No changes were made", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                            // No changes were made
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Carrier capacity limit exceeded.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show($"Error: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    LogEvent("Error", $"Error during save in AssignCarrier_Click");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No carriers available for the selected destination.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an order first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (DbUpdateException dbUpdateEx)
            {
                Exception innerException = dbUpdateEx;

                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                // Display the complete exception details including the inner exception
                MessageBox.Show($"Error during save: {innerException.Message}\n\nStackTrace: {innerException.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to check carrier capacity
        private bool CheckCarrierCapacity(Carrier carrier, int orderQuantity)
        {
            // Check if the carrier has enough capacity to handle the order quantity
            return (carrier.LTLA >= orderQuantity);
        }




        private Order GetSelectedOrder()
        {
            // Your implementation to get the selected order goes here
            // For example, if you have a DataGrid named OrdersGrid, you might do something like this:
            if (OrdersGrid.SelectedItem is Order selectedOrder)
            {
                return selectedOrder;
            }
            else
            {
                MessageBox.Show("Please select an order first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }


        private Trip GetSelectedTrip()
        {
            // Your implementation to get the selected order goes here
            // For example, if you have a DataGrid named OrdersGrid, you might do something like this:
            if (TripGrid.SelectedItem is Trip selectedTrip)
            {
                return selectedTrip;
            }
            else
            {
                MessageBox.Show("Please select an order first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        private void ConfirmOrderComplete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve the selected trip
                Trip selectedTrip = GetSelectedTrip();

                if (selectedTrip != null)
                {
                    // Check if the trip is already marked as completed
                    if (selectedTrip.OrderStatus == "completed")
                    {
                        MessageBox.Show("This trip is already marked as complete.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    // Update status to "completed"
                    selectedTrip.OrderStatus = "completed";

                    // Update the status ID of the associated order
                    using (var context = new TMSDBContext())
                    {
                        // Load the associated order without tracking
                        var associatedOrder = context.Order.AsNoTracking().FirstOrDefault(o => o.OrderID == selectedTrip.OrderID);

                        // Check if the associated order exists
                        if (associatedOrder != null)
                        {
                            // Update the status ID of the associated order
                            associatedOrder.OrderStatus = "completed"/* Set the appropriate status ID for completed orders */;
                            associatedOrder.DeliveryDate = DateTime.Now;

                            // Mark the order as modified using context.Update
                            context.Update(associatedOrder);
                        }

                        // Mark the trip as modified using context.Update
                        context.Update(selectedTrip);

                        // Save the changes to the database
                        int result = context.SaveChanges();

                        if (result > 0)
                        {
                            // Changes were successful
                            MessageBox.Show("Trip marked as complete successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            LogEvent("Info", $"Trip marked as complete for Order ID: {selectedTrip.OrderID}");
                        }
                        else
                        {
                            MessageBox.Show("No changes were made", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            // No changes were made
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a trip first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                LogEvent("Error", $"Error in ConfirmOrderComplete_Click: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ReportAllTimeButton_Click(object sender, RoutedEventArgs e)
        {
            ShowInvoiceReport("All Time");
        }

        private void ReportPastTwoWeeksButton_Click(object sender, RoutedEventArgs e)
        {
            ShowInvoiceReport("Past Two Weeks");
        }

        private void ShowInvoiceReport(string reportType)
        {
            try
            {
                using (var context = new TMSDBContext())
                {
                    DateTime startDate;

                    if (reportType == "Past Two Weeks")
                    {
                        startDate = DateTime.Now.AddDays(-14);
                    }
                    else
                    {
                        startDate = DateTime.MinValue; // Set your desired start date for "All Time" here
                    }

                    var invoices = context.Invoice
                        .Where(i => i.InvoiceDate >= startDate)
                        .ToList();

                    if (invoices.Any())
                    {
                        // You can display the invoices in a new window or dialog here
                        InvoiceReportWindow reportWindow = new InvoiceReportWindow(invoices);
                        reportWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No invoices found for the selected period.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent("Error", $"Error in ShowInvoiceReport: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

            LogEvent("Info", "Buyer has logged out successfully");
            // Close the current window and open the MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
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
