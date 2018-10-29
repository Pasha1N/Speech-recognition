using Speech_recognition.ViewModels;
using System.Windows;

namespace Speech_recognition
{
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainViewMdel mainViewMdel = new MainViewMdel();
            View.MainWindow mainWindw = new View.MainWindow(mainViewMdel);
            mainWindw.Show();
        }
    }
}