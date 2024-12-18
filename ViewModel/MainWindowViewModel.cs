﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CatalogScolarOnline.Model;
using CatalogScolarOnline.Utilities;
using CatalogScolarOnline.Views;

namespace CatalogScolarOnline.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string _email;

        public Students students= new Students();
        public string Email {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(); 
                }
            }
         }
        public string _name { get; set; }
       
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(); 
                }
            }
        }

        private ObservableCollection<Grades> _grades;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CloseCommand { get; }
        public ICommand LoginWindow { get; }
        public ICommand NavigateToNotesCommand { get; }
        public ICommand ShowOrarCommand {  get; }
        public ICommand ShowAbsenteCommand { get; }
        public ICommand ShowMyProfileCommand { get; }
        public MainWindowViewModel()
        {
            
            CloseCommand = new RelayCommand(CloseApplication);
            LoginWindow = new RelayCommand(LoginWindowShow);
            NavigateToNotesCommand = new RelayCommand(NavigateToNotes);
            ShowOrarCommand = new RelayCommand(ShowOrar);
            ShowAbsenteCommand = new RelayCommand(ShowAbsente);
            ShowMyProfileCommand = new RelayCommand(ShowMyProfile);
        }
        private void NavigateToNotes(object parameter)
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                var notePage = new Views.Note();
                notePage.ReceiveEmail(_email);
                
                mainWindow.MainFrame.Navigate(notePage);
            }
        }

        private void ShowOrar(object parameter)
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                var orarPage = new Views.OrarPage();
                

                mainWindow.MainFrame.Navigate(orarPage);
            }
        }

        private void ShowAbsente(object parameter)
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                var absentePage = new Views.Absente();


                mainWindow.MainFrame.Navigate(absentePage);
            }
        }

        private void ShowMyProfile(object parameter)
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                var myProfilePage = new Views.ProfilulMeu();
                mainWindow.MainFrame.Navigate(myProfilePage);
            }
        }

        public void SetEmail(string email)
        {
            this._email = email;
            Email = email;
            Name = students.GetName(this._email);
        }
        private void CloseApplication(object parameter)
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }

        private void LoginWindowShow(object parameter)
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            Login login = new Login();
            login.Show();

            if (currentWindow != null)
            {
                currentWindow.Close();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
