using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using infSystemGuests.masterDataSetTableAdapters;

namespace infSystemGuests
{
    /// <summary>
    /// Логика взаимодействия для AdminChequePage.xaml
    /// </summary>
    public partial class AdminChequePage : Page
    {
        ChequesTableAdapter cheques = new ChequesTableAdapter();
        public AdminChequePage()
        {
            InitializeComponent();
            ChequeTable.ItemsSource = cheques.GetData();
        }

        private void GuestButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminGuestPage();
        }

        private void ReservationButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminReservationPage();
        }

        private void ChequeButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminChequePage();
        }

        private void ReportButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminReportPage();
        }

        private void RoomsButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminRoomPage();
        }

        private void StaffButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AdminStaffPage();
        }

        private void ChequeExportClick(object sender, RoutedEventArgs e)
        {

        }

        private void ChequeDeleteClick(object sender, RoutedEventArgs e)
        {
            if (ChequeTable.SelectedItem != null)
            {
                int id = (int)(ChequeTable.SelectedItem as DataRowView).Row[0];
                cheques.DeleteQueryCheque(id);
                ChequeTable.ItemsSource = cheques.GetData();
            }
            else
            {
                MessageBox.Show("Строка не была выбрана");
            }
        }

        private void ChequeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ChequeTable.SelectedItem as DataRowView;
        }
    }
}
