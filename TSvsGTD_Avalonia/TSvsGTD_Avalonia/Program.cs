using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using System;
using TSvsGTD_Avalonia.ViewModels;
using TSvsGTD_Avalonia.Views;

namespace TSvsGTD_Avalonia
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();

        private static void AppMain(Application app, string[] args)
        {
            var window = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };

            app.Run(window);
        }
    }
}
