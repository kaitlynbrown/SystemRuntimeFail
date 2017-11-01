using System;
using System.Windows;
using System.Windows.Threading;

namespace SystemRuntimeFail
{
    public class Error
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class ErrorHandler
    {
        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            DisplayError((Exception) args.ExceptionObject);
        }

        public static void HandleDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            DisplayError(args.Exception);
            args.Handled = true;
        }

        public static void DisplayError(Exception exception)
        {
            Console.WriteLine(exception);
            DisplayError(exception.Message + Environment.NewLine + exception.StackTrace, exception.GetType().Name);
        }

        public static void DisplayError(Error error)
        {
            DisplayError(error.Body, error.Title, MessageBoxImage.Exclamation);
        }

        public static void DisplayError(string error, string caption,
            MessageBoxImage messageBoxImage = MessageBoxImage.Error)
        {
            MessageBox.Show(error, caption, MessageBoxButton.OK, messageBoxImage);
        }

        
    }
}