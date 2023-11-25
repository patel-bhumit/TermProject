using DataLayer.Context;
using System;
using System.Linq;
using System.Windows;

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

        }
    }
}
