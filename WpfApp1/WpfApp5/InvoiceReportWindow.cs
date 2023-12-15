using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using DataLayer.Model;

namespace WpfApp5
{
    public class InvoiceReportWindow : Window
    {
        private DataGrid invoiceGrid;

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


            // Add components to the window
            StackPanel panel = new StackPanel();
            panel.Children.Add(invoiceGrid);

            Content = panel;
        }

    }
}
