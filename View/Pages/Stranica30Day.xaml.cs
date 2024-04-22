using CalendarEmocia.View.UserInreface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CalendarEmocia.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stranica30Day.xaml
    /// </summary>
    public partial class Stranica30Day : Page
    {
        private DateTime date = DateTime.Now;
        private TranslateTransform translateTransform;

        public Stranica30Day()
        {
            InitializeComponent();
            Refresh();
            UpdateMonthYearTextBlock();

            DayPanel.MouseLeftButtonDown += DayPanel_MouseLeftButtonDown;
            DayPanel.MouseRightButtonDown += DayPanel_MouseRightButtonDown;
        }

        public void perexodkvybory()
        {
            VyborKakoiTiSegodnya.Content = new VyborNastroeniya(); //переход к выбору
        }

        private void Button_Click(object sender, RoutedEventArgs e)//кнопка месяц назад
        {
            date = date.AddMonths(-1);
            Refresh();
            DateTime currentDate = DateTime.Parse(MonthYearTextBlock.Text);
            MonthYearTextBlock.Text = currentDate.AddMonths(-1).ToString("MMMM yyyy");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//кнопка месяц вперед
        {
            date = date.AddMonths(1);
            Refresh();
            DateTime currentDate = DateTime.Parse(MonthYearTextBlock.Text);
            MonthYearTextBlock.Text = currentDate.AddMonths(1).ToString("MMMM yyyy");
        }

        private void UpdateMonthYearTextBlock()
        {
            MonthYearTextBlock.Text = DateTime.Today.ToString("MMMM yyyy");
        }

        private void Refresh()
        {
            DayPanel.Children.Clear();
            daytext.Text = date.ToString();
            for (int i = 1; i <= DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                Iconcka icon = new Iconcka();
                icon.Icon = i.ToString();

                DayPanel.Children.Add(icon);
            }
        }

        private void DayPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VyborKakoiTiSegodnya.Content = new VyborNastroeniya();
        }

        private void DayPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem viewItem = new MenuItem { Header = "Просмотреть" };
            MenuItem clearItem = new MenuItem { Header = "Очистить" };

            contextMenu.Items.Add(viewItem);
            contextMenu.Items.Add(clearItem);

            viewItem.Click += ViewItem_Click;

            contextMenu.IsOpen = true;
        }

        private void ViewItem_Click(object sender, RoutedEventArgs e)
        {
            VyborKakoiTiSegodnya.Content = new VyborNastroeniya();
        }
    }
}
