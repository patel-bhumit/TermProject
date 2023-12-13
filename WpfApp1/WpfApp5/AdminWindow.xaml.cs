using DataLayer.Context;
using System;
using System.Linq;
using System.Windows;

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

        public AdminWindow()
        {
            InitializeComponent();

            try
            {
                using (var TMSContext = new TMSDBContext())
                {
                    CarrierGrid.ItemsSource = TMSContext.Carrier.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                    var carrier = new DataLayer.Model.Carrier
                    {
                        cName = cName,
                        dCity = DestinationCity,
                        FTLA = ftla,
                        LTLA = ltal,
                        FTLARate = FTLr,
                        LTLRate = LTLr,
                        reefCharge = ReefCharge
                    };
                    context.Carrier.Add(carrier);
                    context.SaveChanges();
                    CarrierGrid.ItemsSource = context.Carrier.ToList();
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
                    context.Carrier.Remove(carrier);
                    context.SaveChanges();
                    CarrierGrid.ItemsSource = context.Carrier.ToList();
                }
                else
                {
                    MessageBox.Show("Carrier not found");
                }
            }
        }

    }
}
