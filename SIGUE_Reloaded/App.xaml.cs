﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SIGUE_Reloaded
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            EventManager.RegisterClassHandler(typeof(TextBox),
                                                TextBox.GotFocusEvent,
                                                new RoutedEventHandler(TextBox_GotFocus));
            EventManager.RegisterClassHandler(typeof(PasswordBox),
                                                PasswordBox.GotFocusEvent,
                                                new RoutedEventHandler(PasswordBox_GotFocus));
            base.OnStartup(e);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as PasswordBox).SelectAll();
        }
    }
}
