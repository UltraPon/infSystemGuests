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
using System.Windows.Navigation;
using System.Windows.Shapes;
using infSystemGuests.masterDataSetTableAdapters;

namespace infSystemGuests
{
    /// <summary>
    /// Логика взаимодействия для ManagerReportPage.xaml
    /// </summary>
    public partial class ManagerReportPage : Page
    {
        public ManagerReportPage()
        {
            InitializeComponent();
        }

        private void GuestButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ManagerGuestPage();
        }

        private void ReservationButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ManagerReservationPage();
        }

        private void ChequeButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ManagerChequePage();
        }

        private void ReportButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ManagerReportPage();
        }

        private void RoomsButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ManagerRoomPage();
        }

        private void GuestDeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void ReportSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
