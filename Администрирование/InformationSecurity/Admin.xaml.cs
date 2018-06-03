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
using System.Windows.Shapes;

namespace InformationSecurity
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private Models.Subject subject { get; set; }

        public Admin(Models.Subject subject)
        {
            InitializeComponent();
            this.subject = subject;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RegisterUsers register = new RegisterUsers();
            register.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ChangeLevel changeLevel = new ChangeLevel();
            changeLevel.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ChangeRole changeRole = new ChangeRole();
            changeRole.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ChangeUser changeUser = new ChangeUser();
            changeUser.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
