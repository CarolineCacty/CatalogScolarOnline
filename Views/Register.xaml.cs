﻿using CatalogScolarOnline.ViewModel;
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

namespace CatalogScolarOnline.Views
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                if (this.DataContext is RegisterViewModel viewModel)
                {
                    viewModel.Password = passwordBox.Password;  
                }
            }
        }

        private void grid_register_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
