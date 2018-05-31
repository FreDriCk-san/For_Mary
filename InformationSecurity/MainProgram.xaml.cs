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
    /// Логика взаимодействия для MainProgram.xaml
    /// </summary>
    public partial class MainProgram : Window
    {
        private Models.Subject subject { get; set; }

        public MainProgram(Models.Subject subject)
        {
            InitializeComponent();
            this.subject = subject;
            label1.Content = subject.Login;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
