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
    /// Логика взаимодействия для ReceptionGuestPage.xaml
    /// </summary>
    public partial class ReceptionGuestPage : Page
    {
        GuestsTableAdapter guests = new GuestsTableAdapter();
        public ReceptionGuestPage()
        {
            InitializeComponent();
            GuestTable.ItemsSource = guests.GetData();
        }

        private void GuestButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ReceptionGuestPage();
        }

        private void ReservationButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ReseptionReservationPage();
        }

        private void ChequeButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ReceptionChequePage();
        }

        private void GuestAddClick(object sender, RoutedEventArgs e)
        {
            if (GuestName.Text != "" && GuestSecondName.Text != "" && GuestPhone.Text != "" && GuestEmail.Text != "")
            {
                guests.InsertQueryGuest(GuestName.Text, GuestSecondName.Text, GuestPatronymic.Text, GuestPhone.Text, GuestEmail.Text);
                GuestTable.ItemsSource = guests.GetData();
            }
            else
            {
                MessageBox.Show("Необходимые поля не заполнены");
            }
        }

        private void GuestUpdateClick(object sender, RoutedEventArgs e)
        {
            if (GuestName.Text != "" && GuestSecondName.Text != "" && GuestPhone.Text != "" && GuestEmail.Text != "")
            {
                if (GuestTable.SelectedItem != null)
                {
                    var item = GuestTable.SelectedItem as DataRowView;
                    guests.UpdateQueryGuest(GuestName.Text, GuestSecondName.Text, GuestPatronymic.Text, GuestPhone.Text, GuestEmail.Text, (int)item.Row[0]);
                    GuestTable.ItemsSource = guests.GetData();
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

        private void GuestDeleteClick(object sender, RoutedEventArgs e)
        {
            if (GuestTable.SelectedItem != null)
            {
                int id = (int)(GuestTable.SelectedItem as DataRowView).Row[0];
                guests.DeleteQueryGuest(id);
                GuestTable.ItemsSource = guests.GetData();
            }
            else
            {
                MessageBox.Show("Строка не была выбрана");
            }
        }

        private void GuestSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GuestTable.SelectedItem != null)
            {
                var item = GuestTable.SelectedItem as DataRowView;
                GuestName.Text = Convert.ToString(item.Row[1]);
                GuestSecondName.Text = Convert.ToString(item.Row[2]);
                GuestPatronymic.Text = Convert.ToString(item.Row[3]);
                GuestPhone.Text = Convert.ToString(item.Row[4]);
                GuestEmail.Text = Convert.ToString(item.Row[5]);
            }
        }

        private void PageFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
