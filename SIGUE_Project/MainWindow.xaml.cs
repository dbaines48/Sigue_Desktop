using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace SIGUE_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Color color = (Color)ColorConverter.ConvertFromString("#4c4c4c");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AccessButton.IsEnabled = false;
            txtSchoolCode.Focus();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ProgRing.IsActive = true;
            await Task.Delay(4000);
            ProgRing.IsActive = false;
            await Task.Delay(500);
            this.Visibility = System.Windows.Visibility.Hidden;
            Dashboard d = new Dashboard();
            d.Show();
            this.Close();
        }

        private void txtSchoolCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex er = new Regex(@"^[\d+]+$|^$");
            TextBox tb = sender as TextBox;
            if (!er.IsMatch(tb.Text))
            {
                tb.FontWeight = FontWeights.Normal;
                tb.Foreground = Brushes.Crimson;
            }
            else
            {
                tb.FontWeight = FontWeights.Light;
                tb.Foreground = new System.Windows.Media.SolidColorBrush(color);
            }
            AccessButton.IsEnabled = (er.IsMatch(tb.Text) && !AreFieldsEmpty()) ? true : false;
        }

        private void TheTextChanged(object sender, TextChangedEventArgs e)
        {
            AccessButton.IsEnabled = (!AreFieldsEmpty() && Regex.IsMatch(txtSchoolCode.Text, @"^[\d+]+$|^$")) ? true : false;
        }

        private void ThePasswordChanged(object sender, RoutedEventArgs e)
        {
            AccessButton.IsEnabled = (!AreFieldsEmpty() && Regex.IsMatch(txtSchoolCode.Text, @"^[\d+]+$|^$")) ? true : false;
        }

        private bool AreFieldsEmpty()
        {
            return (String.IsNullOrEmpty(txtSchoolCode.Text) || String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Password));
        }
    }
}
