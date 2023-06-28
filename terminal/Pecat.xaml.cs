using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Speech.Synthesis;
using System.Drawing.Printing;

namespace terminal
{
    /// <summary>
    /// Логика взаимодействия для Pecat.xaml
    /// </summary>
    public partial class Pecat : Window
    {
      
                 public Pecat()
        {
            InitializeComponent();

            MySqlConnection conn = new MySqlConnection("server=localhost; user id = root; password=z213461z; database = ochered"); //строка подключениz
            string sql = "SELECT number FROM spisok ORDER BY idSpisok DESC LIMIT 1";



            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                lbNum.Content = cmd.ExecuteScalar();
                SpeechSynthesizer speechSynth = new SpeechSynthesizer(); // создаём объект
                speechSynth.Volume =100; // устанавливаем уровень звука
                speechSynth.Speak($"Ваш номер {lbNum.Content}"); // озвучиваем переданный текст
                conn.Close();
            }
         
           


            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) }; //переход обратно спустя 10 секунд
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                var page = new MainWindow();
                page.Show();
                this.Close();
            };
        }
    }
}

