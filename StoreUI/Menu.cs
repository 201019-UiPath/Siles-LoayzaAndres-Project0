using System.Text.RegularExpressions;

namespace StoreUI
{
    public abstract class Menu
    {
        protected string userInput;
        protected Menu subMenu;
        protected Menu prevMenu;

        public abstract void Start();

        public abstract void StartAdmin();

        protected bool UserInputIsX()
        {
            string validXpattern = "x|X";
            return Regex.IsMatch(userInput, validXpattern);
        }
    }

}