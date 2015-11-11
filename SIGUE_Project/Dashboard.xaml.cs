using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using System.Xml;

namespace SIGUE_Project
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : MetroWindow
    {
        string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "hello buenas.docx");

        public Dashboard()
        {
            InitializeComponent();
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
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
        }

        private async void Stack_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel stack = sender as StackPanel;
            SelectStack(stack);
        }

        //Selected #666666
        //Not Selected #0c0c0c

        public void SelectStack(StackPanel stack)
        {
            Grid grid = stack.Parent as Grid;
            //Deseleccionar todos los stacks
            DeselectStack(LogoStack);
            DeselectStack(GestionEstuStack);
            DeselectStack(GestionProfStack);
            DeselectStack(GestionAdmStack);
            DeselectStack(ReportStack);
            DeselectStack(SettingsStack);

            //Seleccionar el stack escogido
            Color color = (Color)ColorConverter.ConvertFromString("#666666");
            grid.SetResourceReference(Grid.BackgroundProperty, "AccentColorBrush");
            //grid.Background = new System.Windows.Media.SolidColorBrush(color);

            //Mostrar el tab item segun el escogido
            MetroTabItem st = HomeTabItem;
            switch (stack.Name)
            {
                case "LogoStack":
                    st = HomeTabItem;
                    break;
                case "GestionEstuStack":
                    st = GestionEstuTabItem;
                    break;
                case "GestionProfStack":
                    st = GestionProfTabItem;
                    break;
                case "GestionAdmStack":
                    st = GestionAdmTabItem;
                    break;
                case "ReportStack":
                    st = ReportTabItem;
                    try
                    {
                        Document doc = new Document(path);
                        string xpsFile = path.Replace("docx", "xps");
                        if (!File.Exists(xpsFile))
                            doc.SaveToFile(xpsFile, FileFormat.XPS);
                        XpsDocument document = new XpsDocument(xpsFile, FileAccess.ReadWrite);
                        docViewer1.Document = document.GetFixedDocumentSequence();
                        document.Close();
                        doc.Dispose();
                    }
                    catch
                    {

                    }
                        
                    break;
                case "SettingsStack":
                    st = SettingsTabItem;
                    break;
                default:
                    st = HomeTabItem;
                    break;
            }
            DashTabControl.SelectedIndex = DashTabControl.Items.IndexOf(st);
        }

        public void DeselectStack(StackPanel stack)
        {
            Grid grid = stack.Parent as Grid;
            grid.Background = Brushes.Transparent;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "S.I.G.U.E.";
            SelectStack(LogoStack);
        }


    }
}
