using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestBDMessenger.ServiceMes;

namespace TestBDMessenger
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        MessengerDTEntities2 db;
        ServiceMessengerClient client;
        public AuthorizationWindow()
        {
            InitializeComponent();
            db = new MessengerDTEntities2();
        }
        private void TextEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextEmail.Focus();

        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEmail.Text) && TxtEmail.Text.Length > 0)
            {
                TextEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextEmail.Visibility = Visibility.Visible;
            }

        }

        private void Textpass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Textpass.Focus();

        }

        private void Txtpass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Txtpass.Password) && Txtpass.Password.Length > 0)
            {
                Textpass.Visibility = Visibility.Collapsed;
            }
            else
            {
                Textpass.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db = new MessengerDTEntities2();

            string doudlepass = Txtpass.Password;

            string doubleemail = TxtEmail.Text;

            var userFromDb = db.users.FirstOrDefault(u => u.email == doubleemail && u.password_hash == doudlepass);

            if (userFromDb != null)
            {

                MainWindow mainWindow = new MainWindow(userFromDb.user_id, userFromDb.username);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пароль введен неверно");
            }


            //ServiceMessengerClient client = null;
            //try
            //{
            //    client = new ServiceMessengerClient();

            //    if (client.State == CommunicationState.Faulted)
            //    {
            //        client.Abort();
            //        client = new ServiceMessengerClient();
            //    }

            //    int userId = client.Autoriz(doubleemail, doudlepass);

            //    if (userId != -1)
            //    {
            //        Application.Current.Properties["UserId"] = userId;

            //        MainWindow mainWindow = new MainWindow();
            //        mainWindow.Show();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Пароль введен неверно");
            //    }

            //    client.Close();
            //}
            //catch (CommunicationObjectFaultedException ex)
            //{
            //    MessageBox.Show("Ошибка связи: " + ex.Message);
            //}
            //catch (TimeoutException ex)
            //{
            //    MessageBox.Show("Время ожидания истекло: " + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Произошла ошибка: " + ex.ToString());
            //}
            //finally
            //{
            //    if (client != null && client.State == CommunicationState.Opened)
            //    {
            //        client.Close();
            //    }
            //    else
            //    {
            //        client?.Abort();
            //    }
            //}
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
