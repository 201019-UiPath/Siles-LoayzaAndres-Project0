using System.Text.RegularExpressions;

namespace StoreUI
{
    internal abstract class Menu
    {
        protected string userInput;
        protected Menu subMenu;

        public abstract void Start();

        protected bool UserInputIsX()
        {
            return Regex.IsMatch(userInput, "^x|X$");
        }

        protected bool UserInputIsInt()
        {
            return Regex.IsMatch(userInput, "^[0-9]+$");
        }
    }

}