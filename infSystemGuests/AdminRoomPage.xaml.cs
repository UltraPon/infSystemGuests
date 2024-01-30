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
    /// Логика взаимодействия для AdminRoomPage.xaml
    /// </summary>
    public partial class AdminRoomPage : Page
    {
        RoomsTableAdapter rooms = new RoomsTableAdapter();
        RoomTypesTableAdapter roomTypes = new RoomTypesTableAdapter();
        public AdminRoomPage()
        {
            InitializeComponent();
            RoomTable.ItemsSource = rooms.GetData();
            RoomType.ItemsSource = roomTypes.GetData();
            RoomType.SelectedValuePath = "RoomTypeID";
            RoomType.DisplayMemberPath = "RoomTypeName";
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

        private void RoomAddClick(object sender, RoutedEventArgs e)
        {
            if (RoomNumber.Text != "" && RoomCapacity.Text != "" && RoomType.Text != "" && RoomPrice.Text != "")
            {
                int roomType = (int)RoomType.SelectedValue;
                rooms.InsertQueryRoom(roomType, RoomNumber.Text, Convert.ToInt32(RoomCapacity.Text), Convert.ToDecimal(RoomPrice.Text));
                RoomTable.ItemsSource = rooms.GetData();
            }
            else
            {
                MessageBox.Show("Необходимые поля не заполнены");
            }
        }

        private void RoomUpdateClick(object sender, RoutedEventArgs e)
        {
            if (RoomNumber.Text != "" && RoomCapacity.Text != "" && RoomType.Text != "" && RoomPrice.Text != "")
            {
                if (RoomTable.SelectedItem != null)
                {
                    int roomType = (int)RoomType.SelectedValue;
                    var item = RoomTable.SelectedItem as DataRowView;
                    rooms.UpdateQueryRoom(roomType, RoomNumber.Text, Convert.ToInt32(RoomCapacity.Text), Convert.ToDecimal(RoomPrice.Text), (int)item.Row[0]);
                    RoomTable.ItemsSource = rooms.GetData();
                }
                else
                {
                    MessageBox.Show("Строка не была выбрана");
                }
            }
            else
            {
                MessageBox.Show("Необходимые поля не заполнены");
            }
        }

        private void RoomDeleteClick(object sender, RoutedEventArgs e)
        {
            if (RoomTable.SelectedItem != null)
            {
                int id = (int)(RoomTable.SelectedItem as DataRowView).Row[0];
                rooms.DeleteQueryRoom(id);
                RoomTable.ItemsSource = rooms.GetData();
            }
            else
            {
                MessageBox.Show("Строка не была выбрана");
            }
        }

        private void RoomSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomTable.SelectedItem != null)
            {
                var item = RoomTable.SelectedItem as DataRowView;
                RoomType.Text = Convert.ToString(item.Row[1]);
                RoomNumber.Text = Convert.ToString(item.Row[2]);
                RoomCapacity.Text = Convert.ToString(item.Row[3]);
                RoomPrice.Text = Convert.ToString(item.Row[4]);
            }
        }
    }
}
