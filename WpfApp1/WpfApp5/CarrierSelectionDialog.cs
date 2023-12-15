using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using DataLayer.Model;

namespace WpfApp5
{
    public class CarrierSelectionDialog : Window
    {
        private DataGrid carrierGrid;
        private Button selectButton;

        public Carrier SelectedCarrier { get; private set; }

        public CarrierSelectionDialog(List<Carrier> carriers)
        {
            InitializeUI(carriers);
        }

        private void InitializeUI(List<Carrier> carriers)
        {
            // Initialize the dialog components
            Title = "Select Carrier";
            Width = 400;
            Height = 300;

            carrierGrid = new DataGrid
            {
                ItemsSource = carriers,
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
            panel.Children.Add(carrierGrid);
            panel.Children.Add(selectButton);

            Content = panel;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCarrier = (Carrier)carrierGrid.SelectedItem;
            DialogResult = true;
            Close();
        }
    }
}