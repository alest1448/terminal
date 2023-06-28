using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace terminal
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

        public int AddNumber(string number)
        {
            
            var check = -1;
                MySqlConnection conn = new MySqlConnection("server=localhost; user id = root; password=z213461z; database = ochered"); //строка подключениz
                conn.Open();
                string cndText = $"INSERT INTO Spisok(Number) VALUES('{number}' );"; 
                MySqlCommand cmd = new MySqlCommand(cndText, conn);
                check = cmd.ExecuteNonQuery();

                conn.Close();
                return check;
            }
            private void btPoluch_Click(object sender, RoutedEventArgs e)
        {

            string iPass = "";
            string[] arrb = { "А", "Б", "В", "Г", "Д", "Е", "З", "Ж", "И", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т" };
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Random rnd = new Random();
            for (int i = 0; i < 3; i = i + 1)
            {
                iPass = iPass + arr[rnd.Next(0, 9)];

            }
            for (int j = 0; j < 1; j = j + 1) //генерация номера
            {

                iPass = arrb[rnd.Next(0, 18)] + "-" + iPass;
            }

            if (AddNumber(iPass) > 0) //добавление номера в список
            {
                Pecat window1 = new Pecat();
                window1.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Не удалось завершить действие");

            }

        }
    }
}
