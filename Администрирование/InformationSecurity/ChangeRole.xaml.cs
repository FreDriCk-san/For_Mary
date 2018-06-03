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
    /// Логика взаимодействия для ChangeRole.xaml
    /// </summary>
    public partial class ChangeRole : Window
    {
        private CheckBox[] checkBoxes;
        private Models.Role Role { get; set; }

        public ChangeRole()
        {
            InitializeComponent();
            checkBoxes = new CheckBox[] { checkbox1, checkbox2, checkbox3, checkbox4, checkbox5, checkbox6, checkbox7 };
        }



        private void listUpdate()
        {
            listView1.Items.Clear();
            var defaultTime = new TimeSpan(00, 00, 00);

            var gridView = new GridView();
            listView1.View = gridView;

            gridView.Columns.Add(new GridViewColumn { Header = "Id", DisplayMemberBinding = new Binding("Id") });
            gridView.Columns.Add(new GridViewColumn { Header = "Имя", DisplayMemberBinding = new Binding("Name") });
            gridView.Columns.Add(new GridViewColumn { Header = "Длительность", DisplayMemberBinding = new Binding("AllowedTime") });
            gridView.Columns.Add(new GridViewColumn { Header = "Приоритетность", DisplayMemberBinding = new Binding("Priority") });

            using (var db = new Context.ContextDB())
            {
                foreach (var role in db.Roles)
                {
                    listView1.Items.Add(new Models.Role
                    {
                        Id = role.Id,
                        Name = role.Name,
                        AllowedTime = role.AllowedTime.HasValue ? role.AllowedTime : defaultTime,
                        AllowedDays = role.AllowedDays,
                        Priority = role.Priority
                    });
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
                textBox1.Text = ((obj as Models.Role).Name);
                textBox2.Text = ((obj as Models.Role).AllowedTime).ToString();
                textBox3.Text = ((obj as Models.Role).Priority).ToString();
                this.Role = ((obj as Models.Role));
            }

            foreach (var box in checkBoxes)
            {
                box.IsChecked = false;
            }

            List<string> days = new List<string>();
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < Role.AllowedDays.Length; ++i)
            {
                var curChar = Role.AllowedDays.ElementAt(i);
                if(curChar != ',')
                {
                    builder.Append(curChar);
                }
                else
                {
                    days.Add(builder.ToString());
                    builder.Clear();
                }
            }

            for(int j = 0; j < checkBoxes.Length; ++j)
            {
                for(int s = 0; s < days.Count; ++s)
                {
                    if (days.ElementAt(s).Equals(checkBoxes[j].Content)) checkBoxes[j].IsChecked = true;
                }
            }
        }


        //Add
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var box in checkBoxes)
            {
                if(box.IsChecked == true)
                {
                    builder.Append(box.Content).Append(',');
                }
            }

            if(Methods.Admin.AddRole(textBox1.Text, Convert.ToInt32(textBox3.Text), builder.ToString(), TimeSpan.Parse(textBox2.Text)))
            {
                MessageBox.Show("Added successful");
                listUpdate();
            }
            else
            {
                MessageBox.Show("Something got wrong");
            }
        }


        //Update
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Role.Name = textBox1.Text;
            this.Role.Priority = Convert.ToInt32(textBox3.Text);
            this.Role.AllowedTime = TimeSpan.Parse(textBox2.Text);

            StringBuilder builder = new StringBuilder();

            foreach(var box in checkBoxes)
            {
                if (box.IsChecked == true)
                {
                    builder.Append(box.Content).Append(',');
                }
            }

            this.Role.AllowedDays = builder.ToString();

            if (Methods.Admin.UpdateRole(Role))
            {
                MessageBox.Show("Обновление прошло удачно");
                listUpdate();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так :(");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (Methods.Admin.DeleteRole(Role))
            {
                MessageBox.Show("Удаление прошло успешно");
                listUpdate();
            }
            else
            {
                MessageBox.Show("Ыыыыы((!");
            }
        }
    }
}
