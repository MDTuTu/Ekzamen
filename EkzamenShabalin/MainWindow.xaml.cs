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

namespace EkzamenShabalin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            НаСцену1.Foreground = Brushes.Green;
        }
        int ВесХранилище = 0;
        int ЦенаХранилище = 0;
        int ОтветХранилище = 0;
        private void НаСцену1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Сцена1.Visibility = Visibility.Hidden;
            Сцена2.Visibility = Visibility.Visible;
        }
        private void НаСцену2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Сцена1.Visibility = Visibility.Hidden;
            Сцена3.Visibility = Visibility.Visible;
        }
        Хлеб хл = new Хлеб();
        Заказ зк = new Заказ();
        private void НайтиРезультат_MouseDown(object sender, MouseButtonEventArgs e)
        {
            НаСцену2.IsEnabled = true;
            НаСцену2.Foreground = Brushes.Green;

            ВесХранилище = Convert.ToInt32(Вес.Text);
            хл.ВесХлеб = ВесХранилище;

            ЦенаХранилище = Convert.ToInt32(Цена.Text);
            хл.ЦенаХлеб = ЦенаХранилище;

            хл.Вычисления();
            ОтветХранилище = хл.ВычисленияДанные;

            Результат.Text = ОтветХранилище.ToString();
        }

        private void НайтиСцена3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int Ответы = 0;
            зк.СписокХлеба.Add(НазваниеХлеба.Text);
            зк.КоличестваХлеба.Add(КолвоСцена3.Text);

            Ответы = ОтветХранилище * Convert.ToInt32(КолвоСцена3.Text);
            ОтветСцена3.Text = Ответы.ToString();
        }

        private void НазадСцена3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Сцена1.Visibility = Visibility.Visible;
            Сцена3.Visibility = Visibility.Hidden;
        }

        private void НазадСцена2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Сцена1.Visibility = Visibility.Visible;
            Сцена2.Visibility = Visibility.Hidden;
        }
    }
    class Хлеб()
    {
        public int ВычисленияДанные { get; set; }
        public int ВесХлеб { get; set; }
        public int ЦенаХлеб { get; set; }
        public void Вычисления()
        {
            ВычисленияДанные = ВесХлеб * ЦенаХлеб;
        }
    }
    class Заказ()
    {
        public List<string> СписокХлеба = new List<string>();
        public List<string> КоличестваХлеба = new List<string>();
    }
}
