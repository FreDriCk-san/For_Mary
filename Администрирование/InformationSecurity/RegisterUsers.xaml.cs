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
    /// Логика взаимодействия для RegisterUsers.xaml
    /// </summary>
    public partial class RegisterUsers : Window
    {
        public RegisterUsers()
        {
            InitializeComponent();
        }

        private void listView1_Loaded(object sender, RoutedEventArgs e)
        {
            listUpdate();
        }

        private void listView1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            foreach(object obj in listView1.SelectedItems)
            {
                textBox1.Text = ((obj as Models.UnregisteredSubjects).Login);
                passBox1.Password = "";
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
            }
        }

        private void comboBox1_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Context.ContextDB())
            {
                foreach(var level in db.Levels)
                {
                    comboBox1.Items.Add(level.Name);
                }
            }
        }

        private void comboBox2_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Context.ContextDB())
            {
                foreach (var role in db.Roles)
                {
                    comboBox2.Items.Add(role.Name);
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Methods.Admin.Registration(textBox1.Text, passBox1.Password, comboBox2.SelectedItem.ToString(), comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("User " + textBox1.Text + " was successfully added!");
                listUpdate();
            }
            else
            {
                MessageBox.Show("System ERROR! Call your system admin!");
            }
        }

        private void listUpdate()
        {
            listView1.Items.Clear();

            var gridView = new GridView();
            listView1.View = gridView;

            gridView.Columns.Add(new GridViewColumn { Header = "Id", DisplayMemberBinding = new Binding("Id") });
            gridView.Columns.Add(new GridViewColumn { Header = "Login", DisplayMemberBinding = new Binding("Login") });

            using (var db = new Context.ContextDB())
            {
                foreach (var user in db.UnregSubjects)
                {
                    listView1.Items.Add(new Models.UnregisteredSubjects { Id = user.Id, Login = user.Login });
                }
            }
        }
    }
}
