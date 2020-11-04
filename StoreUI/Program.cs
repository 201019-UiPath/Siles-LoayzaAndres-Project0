using Serilog;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo
                                                               .File("Logs\\UILog.txt")
                                                               .CreateLogger();
            Log.Information("Global logger configured. Program initiated");
            Menu menu = new MainMenu();
            menu.Start();
        }
    }
}
