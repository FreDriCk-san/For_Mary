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
    /// Логика взаимодействия для ChangeLevel.xaml
    /// </summary>
    public partial class ChangeLevel : Window
    {
        private Models.Level level { get; set; }

        public ChangeLevel()
        {
            InitializeComponent();
        }

        private void listView1_Loaded(object sender, RoutedEventArgs e)
        {
            listUpdate();
        }

        private void listView1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            foreach (object obj in listView1.SelectedItems)
            {
                textBox1.Text = ((obj as Models.Level).Name);
                textBox2.Text = ((obj as Models.Level).CountOfEnter).ToString();
                textBox3.Text = ((obj as Models.Level).StartTime).ToString();
                textBox4.Text = ((obj as Models.Level).EndTime).ToString();
                this.level = ((obj as Models.Level));
            }
        }

        private void listUpdate()
        {
            listView1.Items.Clear();
            var defaultTime = new TimeSpan(00,00,00);

            var gridView = new GridView();
            listView1.View = gridView;

            gridView.Columns.Add(new GridViewColumn { Header = "Id", DisplayMemberBinding = new Binding("Id") });
            gridView.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name") });
            gridView.Columns.Add(new GridViewColumn { Header = "CountOfEnter", DisplayMemberBinding = new Binding("CountOfEnter") });
            gridView.Columns.Add(new GridViewColumn { Header = "StartTime", DisplayMemberBinding = new Binding("StartTime") });
            gridView.Columns.Add(new GridViewColumn { Header = "EndTime", DisplayMemberBinding = new Binding("EndTime") });

            using (var db = new Context.ContextDB())
            {
                foreach (var level in db.Levels)
                {
                    listView1.Items.Add(new Models.Level { Id = level.Id,
                        Name = level.Name,
                        CountOfEnter = level.CountOfEnter.HasValue ? level.CountOfEnter : 0,
                        StartTime = level.StartTime.HasValue ? level.StartTime : defaultTime,
                        EndTime = level.EndTime.HasValue ? level.EndTime : defaultTime });
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Methods.Admin.AddLevel(textBox1.Text, Convert.ToInt32(textBox2.Text), TimeSpan.Parse(textBox3.Text), TimeSpan.Parse(textBox4.Text)))
            {
                MessageBox.Show("Level added successful");
                listUpdate();
            }
            else
            {
                MessageBox.Show("Something got wrong!");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.level.Name = textBox1.Text;
            this.level.CountOfEnter = Convert.ToInt32(textBox2.Text);
            this.level.StartTime = TimeSpan.Parse(textBox3.Text);
            this.level.EndTime = TimeSpan.Parse(textBox4.Text);

            if (Methods.Admin.UpdateLevel(level))
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
            if (Methods.Admin.DeleteLevel(level))
            {
                MessageBox.Show("Deleted successful");
                listUpdate();
            }
            else
            {
                MessageBox.Show("Something got wrong!");
            }
        }

    }
}
