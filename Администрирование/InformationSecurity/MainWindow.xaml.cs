using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        private int counter = 0;
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Subject subject = Methods.Subjects.Authorization(textBox1.Text, passBox1.Password);

            if (null != subject && CheckDay(subject) && CheckTime(subject))
            {
                MessageBox.Show("Авторизация успешно завершена.");
                if(subject.RoleId == 1)
                {
                    Admin admin = new Admin(subject);
                    admin.Show();
                }
                else
                {
                    try
                    {
                        MainProgram mainProgram = new MainProgram(subject);
                        mainProgram.Show();
                    }
                    catch { }
                }
                this.Close();
            }
            else
            {
                counter++;
                MessageBox.Show("Ошибка! Проверьте введённые данные!!");

                if (counter == 3)
                {
                    button1.IsEnabled = false;
                    button2.IsEnabled = false;
                    timer.Tick += new EventHandler(buttonsBlock);
                    timer.Interval = new TimeSpan(0, 0, 40);                                                        //Блочит доступ к авторизации\регистрации на 40 секунд
                    timer.Start();
                    counter = 0;
                }
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


        private bool CheckDay(Subject subject)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var role = db.Roles.FirstOrDefault(r => r.Id == subject.RoleId);
                    StringBuilder builder = new StringBuilder();

                    for (int i = 0; i < role.AllowedDays.Length; ++i)
                    {
                        var curChar = role.AllowedDays.ElementAt(i);
                        if (curChar != ',')
                        {
                            builder.Append(curChar);
                        }
                        else
                        {
                            if (DateTime.Now.DayOfWeek.ToString().Equals(builder.ToString()))
                            {
                                return true;
                            }
                            builder.Clear();
                        }
                    }
                }
            }
            catch { }

            return false;
        }


        private bool CheckTime(Subject subject)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var sTime = db.Levels.FirstOrDefault(t => t.Id == subject.LevelId).StartTime;
                    var eTime = db.Levels.FirstOrDefault(t => t.Id == subject.LevelId).EndTime;

                    if((DateTime.Now.TimeOfDay >= sTime && DateTime.Now.TimeOfDay <= eTime) || null == sTime || null == eTime)
                    {
                        return true;
                    }
                }
            }
            catch { }

            return false;
        }


        private void buttonsBlock(object sender, EventArgs e)
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            timer.Stop();
        }
    }
}
