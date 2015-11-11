using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SIGUE_Project
{
    class DocViewer : DocumentViewer
    {
        protected async override void OnPrintCommand()
        {
            MessageBoxResult result = MessageBox.Show("Confirme impresión.", "Imprimir documento", MessageBoxButton.YesNo);
            if(result.Equals(MessageBoxResult.Yes))
                base.OnPrintCommand();
        }
    }
}
