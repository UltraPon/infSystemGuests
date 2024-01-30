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
    /// Логика взаимодействия для AdminStaffPage.xaml
    /// </summary>
    public partial class AdminStaffPage : Page
    {
        StaffTableAdapter staffs = new StaffTableAdapter();
        RolesTableAdapter roles = new RolesTableAdapter();
        public AdminStaffPage()
        {
            InitializeComponent();
            StaffTable.ItemsSource = staffs.GetData();
            StaffRole.ItemsSource = roles.GetData();
            StaffRole.SelectedValuePath = "RoleID";
            StaffRole.DisplayMemberPath = "RoleName";
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

        private void StaffAddClick(object sender, RoutedEventArgs e)
        {
            if (StaffLogin.Text != "" && StaffPassword.Text != "" && StaffRole.Text != "")
            {
                int staffRole = (int)StaffRole.SelectedValue;
                staffs.InsertQueryStaff(StaffLogin.Text, StaffPassword.Text, staffRole);
                StaffTable.ItemsSource = staffs.GetData();
            }
            else
            {
                MessageBox.Show("Необходимые поля не заполнены");
            }
        }

        private void StaffUpdateClick(object sender, RoutedEventArgs e)
        {
            if (StaffLogin.Text != "" && StaffPassword.Text != "" && StaffRole.Text != "")
            {
                if (StaffTable.SelectedItem != null)
                {
                    int staffRole = (int)StaffRole.SelectedValue;
                    var item = StaffTable.SelectedItem as DataRowView;
                    staffs.UpdateQueryStaff(StaffLogin.Text, StaffPassword.Text, staffRole, (int)item.Row[0]);
                    StaffTable.ItemsSource = staffs.GetData();
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

        private void StaffDeleteClick(object sender, RoutedEventArgs e)
        {
            if (StaffTable.SelectedItem != null)
            {
                int id = (int)(StaffTable.SelectedItem as DataRowView).Row[0];
                staffs.DeleteQueryStaff(id);
                StaffTable.ItemsSource = staffs.GetData();
            }
            else
            {
                MessageBox.Show("Строка не была выбрана");
            }
        }

        private void StaffSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StaffTable.SelectedItem != null)
            {
                var item = StaffTable.SelectedItem as DataRowView;
                StaffLogin.Text = Convert.ToString(item.Row[1]);
                StaffPassword.Text = Convert.ToString(item.Row[2]);
                StaffRole.Text = Convert.ToString(item.Row[3]);
            }
        }
    }
}
