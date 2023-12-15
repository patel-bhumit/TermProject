using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataLayer.Model;
using System.Windows.Controls;
using System.Text;
using System.Xml.Linq;
using DataLayer.Model.DataLayer.Model;
using System.IO;
using System.Windows.Media;
using OfficeOpenXml;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for BuyerPage.xaml
    /// </summary>
    public partial class BuyerPage : Window
    {
       

        public BuyerPage()
        {
            InitializeComponent();

            try
            {
                using (var context = new ContractDB())
                {
                    ContractGrid.ItemsSource = context.Contract.ToList();
                }

                using (var context = new TMSDBContext())
                {
                    CompletedOrderGrid.ItemsSource = context.Order.Where(o => o.OrderStatus == "Completed").ToList();
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ContractDB())
            {
                ContractGrid.ItemsSource = null;
                ContractGrid.ItemsSource = context.Contract.ToList();
            }

            using (var context = new TMSDBContext())
            {
                CompletedOrderGrid.ItemsSource = null;
                CompletedOrderGrid.ItemsSource = context.Order.Where(o => o.OrderStatus == "Completed").ToList();
            }

        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ContractDB())
                {
                    // Get the selected customer from the DataGrid
                    var selectedCustomer = ContractGrid.SelectedItem as Contract;

                    if (selectedCustomer != null)
                    {
                        using (var context2 = new TMSDBContext())
                        {
                            try
                            {
                                // Create a new Customer associated with the selected customer
                                Customer newCustomer = new Customer
                                {
                                    ClientName = selectedCustomer.Client_Name,
                                    JobType = selectedCustomer.Job_Type,
                                    Quantity = selectedCustomer.Quantity,
                                    Origin = selectedCustomer.Origin,
                                    Destination = selectedCustomer.Destination,
                                    VanType = selectedCustomer.Van_Type,

                                    // Add other properties of the Customer as needed
                                };

                                // Display a MessageBox for Customer review
                                var result = MessageBox.Show(
                                    $"Review Customer:\nClient Name: {newCustomer.ClientName}\nJob Type: {newCustomer.JobType}\nQuantity: {newCustomer.Quantity}\nOrigin: {newCustomer.Origin}\nDestination: {newCustomer.Destination}\nVan Type: {newCustomer.VanType}",
                                    "Review Customer",
                                    MessageBoxButton.OKCancel,
                                    MessageBoxImage.Information
                                );

                                // If the user confirms, add the new Customer to the Customer table
                                if (result == MessageBoxResult.OK)
                                {
                                    context2.Customer.Add(newCustomer);
                                    context2.SaveChanges();
                                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                    LogEvent("Info", $"Customer added successfully. Client Name: {newCustomer.ClientName}, Customer ID: {newCustomer.CustomerID}");
                                }
                                else
                                {
                                    MessageBox.Show("Customer addition canceled.", "Canceled", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please select a customer to add.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent("Error", $"Error adding customer: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitiateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new TMSDBContext())
                {
                    // Retrieve customer details from the Customer table
                    var customers = context.Customer.ToList();

                    if (customers.Any())
                    {
                        // Display custom dialog for customer selection
                        var dialog = new CustomerSelectionDialog(customers);
                        bool? result = dialog.ShowDialog();

                        if (result == true && dialog.SelectedCustomer != null)
                        {
                            // Create a new order associated with the selected customer
                            Order newOrder = new Order
                            {
                                ClientName = dialog.SelectedCustomer.ClientName,
                                JobType = dialog.SelectedCustomer.JobType,
                                Quantity = dialog.SelectedCustomer.Quantity,
                                Origin = dialog.SelectedCustomer.Origin,
                                Destination = dialog.SelectedCustomer.Destination,
                                VanType = dialog.SelectedCustomer.VanType,
                                OrderDate = DateTime.Now,
                                OrderStatus = "Pending" // Set the order status directly

                                // Add other properties of the order as needed
                            };

                            // Add the new order to the Orders table
                            context.Order.Add(newOrder);
                            context.SaveChanges();

                            // Remove the selected customer from the Customer table
                            var customerToRemove = context.Customer.Find(dialog.SelectedCustomer.CustomerID);
                            context.Customer.Remove(customerToRemove);

                            context.SaveChanges();

                            MessageBox.Show("Order added successfully!", "Success", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                            LogEvent("Info", $"Order initiated successfully for Client Name: {newOrder.ClientName}, Order ID: {newOrder.OrderID}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No customers found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent("Error", $"Error initiating order: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        // Method to display customer details in a selection dialog
        private Customer SelectCustomerDialog(List<Customer> customers)
        {
            var customerStringBuilder = new StringBuilder();
            customerStringBuilder.AppendLine("Select a customer:");

            foreach (var customer in customers)
            {
                customerStringBuilder.AppendLine($"ID: {customer.CustomerID}, Client Name: {customer.ClientName}, Origin: {customer.Origin}, Destination: {customer.Destination}");
            }

            var result = MessageBox.Show(customerStringBuilder.ToString(), "Select Customer", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK)
            {
                // Get the selected customer
                int selectedCustomerId;
                if (int.TryParse(MessageBox.Show("Enter the ID of the selected customer:", "Enter ID", MessageBoxButton.OKCancel, MessageBoxImage.Information).ToString(), out selectedCustomerId))
                {
                    return customers.FirstOrDefault(c => c.CustomerID == selectedCustomerId);
                }
            }

            return null;
        }


        private void GenerateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set the LicenseContext to properly license EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var context = new TMSDBContext())
                {
                    // Get completed orders for the buyer that do not have an associated invoice
                    var completedOrdersWithoutInvoice = context.Order
                        .Where(o => o.OrderStatus == "completed" && o.Invoice == null)
                        .ToList();

                    if (completedOrdersWithoutInvoice.Any())
                    {
                        // Generate invoices for completed orders without an associated invoice
                        foreach (var order in completedOrdersWithoutInvoice)
                        {
                            if (order.Invoice == null)
                            {
                                Invoice newInvoice = new Invoice
                                {
                                    OrderID = order.OrderID,
                                    ClientName = order.ClientName,
                                    TotalAmount = CalculateTotalAmount(order), // You need to implement this method
                                    InvoiceDate = DateTime.Now
                                };

                                context.Invoice.Add(newInvoice);


                                // Associate the invoice with the order
                                order.Invoice = "Done";

                                // Assuming InvoiceDate is stored as an OLE Automation Date
                                String invoiceDate = newInvoice.InvoiceDate.ToString("M/d/yyyy");


                                // Save changes to the database
                                context.SaveChanges();

                                // Generate Excel file for the Invoice (assuming you have the necessary logic)
                                GenerateInvoiceFile(newInvoice, invoiceDate);
                                // Log the information about successful invoice generation
                                LogEvent("Info", $"Invoice generated successfully for Order ID: {order.OrderID}");

                            }
                        }

                        // Generate invoice file
                        MessageBox.Show("Invoices generated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No completed orders without an associated invoice.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent("Error", $"Error generating invoices: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private double CalculateTotalAmount(Order order)
        {

            double totalAmount = 0;

            using (var context = new TMSDBContext())
            {
                var carrier = context.Carrier.FirstOrDefault(c => c.cID == order.cID);

                if (carrier != null)
                {

                    totalAmount = order.Quantity * (carrier.FTLARate + carrier.LTLRate + carrier.reefCharge);
                }
            }
            
            return totalAmount;
        }

        private void GenerateInvoiceFile(Invoice invoice, string invoiceDate)
        {
            try
            {
                // Create a new Excel package
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    // Add a worksheet to the package
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Invoice");

                    // Add data to the worksheet (customize this based on your needs)
                    worksheet.Cells["A1"].Value = "Order ID";
                    worksheet.Cells["B1"].Value = "Client Name";
                    worksheet.Cells["C1"].Value = "Total Amount";
                    worksheet.Cells["D1"].Value = "Invoice Date";

                    worksheet.Cells["A2"].Value = invoice.OrderID;
                    worksheet.Cells["B2"].Value = invoice.ClientName;
                    worksheet.Cells["C2"].Value = invoice.TotalAmount;
                    worksheet.Cells["D2"].Value = invoiceDate;

                    // Save the Excel package to a stream
                    MemoryStream stream = new MemoryStream(excelPackage.GetAsByteArray());

                    // Convert the stream to a byte array
                    byte[] byteArray = stream.ToArray();

                    // Save the byte array to a file (you can customize the file path and name)
                    string filePath = $"Invoice/Invoice_{invoice.OrderID}.xlsx";
                    File.WriteAllBytes(filePath, byteArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
