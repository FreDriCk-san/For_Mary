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
        private TimeSpan allowedTime;
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public MainProgram(Models.Subject subject)
        {
            InitializeComponent();
            this.subject = subject;
            label1.Content = subject.Login;

            //Считывание дозволенного времени (из таблицы Role -> AllowedTime)... Подумай, зачем я поставил try catch
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var time = db.Roles.FirstOrDefault(t => t.Id == subject.RoleId).AllowedTime;
                    allowedTime = (TimeSpan)time;
                }
            }
            catch { }

            TimeIsUp(allowedTime);

            label2.Content = allowedTime.ToString();
            timer.Tick += new EventHandler(TimeLeft);                                                                   //На каждый тик будет проходить событие TimeLeft
            timer.Interval = new TimeSpan(0, 0, 1);                                                                     //Установка интервала таймера (таймер с интервалом в 1 секунду)
            timer.Start();                                                                                              //Ну... Думаю подобное и так понятно...

        }

        //Если время вышло
        private void TimeIsUp(TimeSpan time)
        {
            if (time <= new TimeSpan(0, 0, 0))
            {
                timer.Stop();
                FixTime();
                MessageBox.Show("Ваше время вышло, милорд! Пора платить налоги!");
                this.Close();
            }
        }

        //Записываем время в Базу Данных
        private void FixTime()
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var time = db.Roles.FirstOrDefault(t => t.Id == subject.RoleId);
                    time.AllowedTime = allowedTime;
                    db.SaveChanges();
                }
            }
            catch { }
        }

        //Отображение оставшегося времени
        private void TimeLeft(object sender, EventArgs e)
        {
            label2.Content = allowedTime.ToString();
            allowedTime -= new TimeSpan(0, 0, 1);
            TimeIsUp(allowedTime);
        }

        //Возвращение в окно авторизации\регистрации
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            FixTime();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //Смена пароля
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(Methods.Subjects.ChangePassword(subject, passBox1.Password))
            {
                MessageBox.Show("Изменение прошло успешно");
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
