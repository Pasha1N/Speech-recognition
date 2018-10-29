using Speech_recognition.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Speech_recognition.View
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewMdel mainViewMdel)
        {
            InitializeComponent();

            DataContext = mainViewMdel;
        }
    }
}