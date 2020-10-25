using StoreBL;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new MainMenu();
            menu.Start();
            
            /*
            Shop shop = new Shop();
            shop.CreateLocations();
            */
        }
    }
}
