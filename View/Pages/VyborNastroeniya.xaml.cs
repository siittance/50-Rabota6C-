﻿using CalendarEmocia.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;
using CalendarEmocia.View.UserInreface;
using System.Windows.Controls.Primitives;

namespace CalendarEmocia
{
    /// <summary>
    /// Логика взаимодействия для VyborNastroeniya.xaml
    /// </summary>
    public partial class VyborNastroeniya : Page
    {
        DateTime date = DateTime.Now;
        public VyborNastroeniya(DateTime date)
        {
            InitializeComponent();

            Dni.Text = date.ToString("dd MMMM yyyy г.");

        }

        private void perexod()
        {
            VozvratKCalendaru.Content = new Stranica30Day();
        }
        private void ReturnVCalendar(object sender, RoutedEventArgs e)
        {
            perexod();
        }

        private void SaveAndExit(object sender, RoutedEventArgs e)
        {
            perexod();
        }

    }
}
