using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using DataLayer.Model;

namespace WpfApp5
{
    public class InvoiceReportWindow : Window
    {
        private DataGrid invoiceGrid;
        private Button selectButton;

        public Invoice SelectedInvoice { get; private set; }

        public InvoiceReportWindow(List<Invoice> invoices)
        {
            InitializeUI(invoices);
        }

        private void InitializeUI(List<Invoice> invoices)
        {
            // Initialize the window components
            Title = "Invoice Report";
            Width = 600;
            Height = 400;

            invoiceGrid = new DataGrid
            {
                ItemsSource = invoices,
                AutoGenerateColumns = true,
                SelectionMode = DataGridSelectionMode.Single,
                Margin = new Thickness(10)
            };

            selectButton = new Button
            {
                Content = "Select Invoice",
                Width = 120,
                Height = 30,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            selectButton.Click += SelectButton_Click;

            // Add components to the window
            StackPanel panel = new StackPanel();
            panel.Children.Add(invoiceGrid);
            panel.Children.Add(selectButton);

            Content = panel;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedInvoice = (Invoice)invoiceGrid.SelectedItem;

            if (SelectedInvoice != null)
            {
                // You can handle the selected invoice here
                // For example, display its details, print, or export
                MessageBox.Show($"Selected Invoice ID: {SelectedInvoice.InvoiceID}", "Selected Invoice", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select an invoice.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
