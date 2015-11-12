using MahApps.Metro.Controls;
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

namespace SIGUE_Reloaded
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : MetroWindow
    {
        public Intro()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
        }

        private async void Intro_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
            introRing.IsActive = true;
            await Task.Delay(4500);
            Login log = new Login();
            this.Close();
            log.Show();
        }


    }
}
