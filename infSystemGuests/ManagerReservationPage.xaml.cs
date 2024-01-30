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
    /// Логика взаимодействия для ManagerReservationPage.xaml
    /// </summary>
    public partial class ManagerReservationPage : Page
    {
        ReservationsTableAdapter reservations = new ReservationsTableAdapter();
        public ManagerReservationPage()
        {
            InitializeComponent();
            ReservationTable.ItemsSource = reservations.GetData();
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

        private void ReservationAddClick(object sender, RoutedEventArgs e)
        {
            if (GuestID.Text != "" && RoomID.Text != "" && CheckInDate.Text != "" && CheckOutDate.Text != "")
            {
                reservations.InsertQueryReservation(Convert.ToInt32(GuestID.Text), Convert.ToInt32(RoomID.Text), CheckInDate.Text, CheckOutDate.Text);
                ReservationTable.ItemsSource = reservations.GetData();
            }
            else
            {
                MessageBox.Show("Необходимые поля не заполнены");
            }
        }

        private void ReservationDeleteClick(object sender, RoutedEventArgs e)
        {
            if (ReservationTable.SelectedItem != null)
            {
                int id = (int)(ReservationTable.SelectedItem as DataRowView).Row[0];
                reservations.DeleteQueryReservation(id);
                ReservationTable.ItemsSource = reservations.GetData();
            }
            else
            {
                MessageBox.Show("Строка не была выбрана");
            }
        }

        private void ReservationSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReservationTable.SelectedItem != null)
            {
                var item = ReservationTable.SelectedItem as DataRowView;
                GuestID.Text = Convert.ToString(item.Row[1]);
                RoomID.Text = Convert.ToString(item.Row[2]);
                CheckInDate.Text = Convert.ToString(item.Row[3]);
                CheckOutDate.Text = Convert.ToString(item.Row[4]);
            }
        }
    }
}
