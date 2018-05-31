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
    /// Логика взаимодействия для ChangeUser.xaml
    /// </summary>
    public partial class ChangeUser : Window
    {
        private Models.Subject Subject { get; set; }

        public ChangeUser()
        {
            InitializeComponent();
        }

        private void comboBox1_Loaded(object sender, RoutedEventArgs e)
        {
            using(var db = new Context.ContextDB())
            {
                foreach(var Role in db.Roles)
                {
                    comboBox1.Items.Add(Role.Name);
                }
            }
        }

        private void comboBox2_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Context.ContextDB())
            {
                foreach (var Level in db.Levels)
                {
                    comboBox2.Items.Add(Level.Name);
                }
            }
        }

        private void listView1_Loaded(object sender, RoutedEventArgs e)
        {
            listUpdate();
        }

        private void listView1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            foreach (object obj in listView1.SelectedItems)
            {
                this.Subject = (obj as Models.Subject);
                using (var db = new Context.ContextDB())
                {
                    var roleName = db.Roles.FirstOrDefault(r => r.Id == Subject.RoleId).Name;
                    var levelName = db.Levels.FirstOrDefault(l => l.Id == Subject.LevelId).Name;
                    comboBox1.SelectedItem = roleName;
                    comboBox2.SelectedItem = levelName;
                }
                textBox1.Text = ((obj as Models.Subject).Login);
                textBox2.Text = ((obj as Models.Subject).Password);
                textBox3.Text = ((obj as Models.Subject).BanId.ToString());
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Subject.Login = textBox1.Text;
            this.Subject.Password = textBox2.Text;
            try
            {
                this.Subject.BanId = Convert.ToInt32(textBox3.Text);
            }
            catch { }

            using (var db = new Context.ContextDB())
            {
                var roleId = db.Roles.FirstOrDefault(r => r.Name == comboBox1.SelectedItem.ToString()).Id;
                var levelId = db.Levels.FirstOrDefault(l => l.Name == comboBox2.SelectedItem.ToString()).Id;
                this.Subject.RoleId = roleId;
                this.Subject.LevelId = levelId;
            }

            
            if (Methods.Admin.UpdateSubject(Subject))
            {
                MessageBox.Show("Updating complete");
                listUpdate();
            }
            else
            {
                MessageBox.Show("Something got wrong!");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (Methods.Admin.DeleteSubject(Subject))
            {
                MessageBox.Show("Удаление прошло успешно");
                listUpdate();
            }
            else
            {
                MessageBox.Show("Ыыыыы((!");
            }
        }

        private void listUpdate()
        {
            listView1.Items.Clear();

            var gridView = new GridView();
            listView1.View = gridView;

            gridView.Columns.Add(new GridViewColumn { Header = "Id", DisplayMemberBinding = new Binding("Id") });
            gridView.Columns.Add(new GridViewColumn { Header = "Логин", DisplayMemberBinding = new Binding("Login") });
            gridView.Columns.Add(new GridViewColumn { Header = "Пароль", DisplayMemberBinding = new Binding("Password") });

            using (var db = new Context.ContextDB())
            {
                foreach (var user in db.Subjects)
                {
                    listView1.Items.Add(new Models.Subject { Id = user.Id, Login = user.Login, Password = user.Password, AuthCount = user.AuthCount, LevelId = user.LevelId, RoleId = user.RoleId, BanId = user.BanId });
                }
            }
        }
    }
}
