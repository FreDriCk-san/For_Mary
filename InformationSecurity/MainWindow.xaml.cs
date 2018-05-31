using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using InformationSecurity.Models;

namespace InformationSecurity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Subject subject = Methods.Subjects.Authorization(textBox1.Text, passBox1.Password);

            if (null != subject)
            {
                MessageBox.Show("Authorization Complete!");
                if(subject.RoleId == 1)
                {
                    Admin admin = new Admin(subject);
                    admin.Show();
                }
                else
                {
                    MainProgram mainProgram = new MainProgram(subject);
                    mainProgram.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Error! Check your input data!");
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (Methods.Subjects.RegisterTask(textBox2.Text))
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Something got wrong! Call your system admin!");
            }
        }
    }
}
