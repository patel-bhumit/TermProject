using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using DataLayer.Model;

namespace WpfApp5
{
    public class CustomerSelectionDialog : Window
    {
        private DataGrid customerGrid;
        private Button selectButton;

        public Customer SelectedCustomer { get; private set; }

        public CustomerSelectionDialog(List<Customer> customers)
        {
            InitializeUI(customers);
        }

        private void InitializeUI(List<Customer> customers)
        {
            // Initialize the dialog components
            Title = "Select Customer";
            Width = 400;
            Height = 300;

            customerGrid = new DataGrid
            {
                ItemsSource = customers,
                AutoGenerateColumns = true,
                SelectionMode = DataGridSelectionMode.Single,
                Margin = new Thickness(10)
            };

            selectButton = new Button
            {
                Content = "Select",
                Width = 100,
                Height = 30,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            selectButton.Click += SelectButton_Click;

            // Add components to the dialog
            StackPanel panel = new StackPanel();
            panel.Children.Add(customerGrid);
            panel.Children.Add(selectButton);

            Content = panel;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCustomer = (Customer)customerGrid.SelectedItem;
            DialogResult = true;
            Close();
        }
    }
}