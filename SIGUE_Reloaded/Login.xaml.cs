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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIGUE_Reloaded
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {

        SigueFunctions sigue = new SigueFunctions();

        public Login()
        {
            InitializeComponent();
        }

        private async void AccessButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = new MetroDialogSettings{
                AffirmativeButtonText = "Entiendo"
            };

            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Password))
            {
                try
                {
                    AccessButton.IsEnabled = false;
                    await Task.Delay(1000);
                    ProgRing.IsActive = true;
                    SigueObjets.tkn Token = sigue.trylogin(txtUsername.Text, txtPassword.Password);
                    switch (Token.role)
                    {
                        case "rector":
                            string tk = Token.token;
                            RectorMainPage rmp = new RectorMainPage(tk);
                            this.Close();
                            rmp.Show();
                            break;
                        case "student":

                            break;
                        default:

                            break;
                    }
                }catch(Exception){
                    this.ShowMessageAsync("Error", sigue.error);
                }
                finally
                {
                    ProgRing.IsActive = false;
                    AccessButton.IsEnabled = true;
                }
            }
            else
            {
                await this.ShowMessageAsync("Advertencia", "Llene los campos antes de iniciar sesión.",MessageDialogStyle.Affirmative,settings);
            }
        }

        private void txtSchoolCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void theTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
