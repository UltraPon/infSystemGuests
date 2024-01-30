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
using MaterialDesignColors;
using infSystemGuests.masterDataSetTableAdapters;

namespace infSystemGuests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StaffTableAdapter adapter = new StaffTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginString.Text) || string.IsNullOrEmpty(passwordString.Password))
            {
                MessageBox.Show("Не все строки были заполнены");
                return;
            }

            var allreg = adapter.GetData().Rows;
            for (int i = 0; i < allreg.Count; i++)
            {
                if (allreg[i][1].ToString() == loginString.Text &&
                    allreg[i][2].ToString() == passwordString.Password)
                {
                    int roleId = (int)allreg[i][3];
                    NavigateToRolePage(roleId);
                    return;
                }
            }

            MessageBox.Show("Неверно введён логин или пароль, повторите попытку.");
        }

        private void NavigateToRolePage(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    AdminMainMenu.Content = new AdminMenuPage();
                    break;

                case 2:
                    ManagerMainMenu.Content = new ManagerMenuPage();
                    break;

                case 3:
                    ReceptionMainMenu.Content = new ReceptionMenuPage();
                    break;
            }

            loginString.Visibility = Visibility.Hidden;
            passwordString.Visibility = Visibility.Hidden;
            authorizationText.Visibility = Visibility.Hidden;
            enterButton.Visibility = Visibility.Hidden;
        }
    }
}
