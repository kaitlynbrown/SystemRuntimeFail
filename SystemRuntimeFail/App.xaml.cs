using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;

namespace SystemRuntimeFail
{
    public partial class App : Application
    {
        static App()
        {
            AppDomain.CurrentDomain.UnhandledException += ErrorHandler.HandleUnhandledException;
            DispatcherHelper.Initialize();
        }

        public App()
        {
            DispatcherUnhandledException += ErrorHandler.HandleDispatcherUnhandledException;
        }

        private void AppStart(object sender, StartupEventArgs args)
        {
            Messenger.Default.Register<Error>(this, ErrorHandler.DisplayError);
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
