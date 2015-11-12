using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class RectorMainPage : MetroWindow
    {
        SigueFunctions sigue = new SigueFunctions();
        string Token;

        public RectorMainPage(string Token)
        {
            InitializeComponent();
            this.Token = Token;
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Theme;
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Salir",
                NegativeButtonText = "Cancelar"
            };

            MessageDialogResult result = await this.ShowMessageAsync("Salir de S.I.G.U.E.", "Confirma que desea cerrar sesión?", MessageDialogStyle.AffirmativeAndNegative, mySettings);
            if (result == MessageDialogResult.Affirmative)
            {
                Intro m = new Intro();
                m.Show();
                this.Close();
            }
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                SigueObjets.Aplications[] apps = sigue.getAplications(Token);
                List<DataItem> dis = new List<DataItem>();
                if (apps.Length > 0)
                {
                    foreach (SigueObjets.Aplications app in apps)
                    {
                        dis.Add(new DataItem() { Fecha = Convert.ToDateTime(app.created_at).ToShortDateString(), Nombres = app.applicant_names, Apellidos = app.applicant_father_surname + app.applicant_mother_surname });
                    }
                    RequestsGrid.ItemsSource = dis;
                    RequestsGrid.Columns[0].Width = 120;
                    RequestsGrid.Columns[1].Width = 150;
                    RequestsGrid.Columns[2].Width = 150;
                }
            }catch(Exception ex){
                this.ShowMessageAsync("Error", sigue.error);
            }
        }

        private void RequestsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //RequestsGrid.Items.Clear();
                SigueObjets.Aplications[] apps = sigue.getAplications(Token);
                List<DataItem> dis = new List<DataItem>();
                if (apps.Length > 0)
                {
                    foreach (SigueObjets.Aplications app in apps)
                    {
                        dis.Add(new DataItem() { Fecha = Convert.ToDateTime(app.created_at).ToShortDateString(), Nombres = app.applicant_names, Apellidos = app.applicant_father_surname + app.applicant_mother_surname });
                    }
                    RequestsGrid.ItemsSource = dis;
                    RequestsGrid.Columns[0].Width = 120;
                    RequestsGrid.Columns[1].Width = 150;
                    RequestsGrid.Columns[2].Width = 150;
                }
            }catch(Exception ex){
                this.ShowMessageAsync("Error", ex.Message);
            }
        }
    }

    public class DataItem
    {
        public string Fecha { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}
