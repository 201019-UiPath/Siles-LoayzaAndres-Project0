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
            string validXpattern = "x|X";
            return Regex.IsMatch(userInput, validXpattern);
        }

        protected bool UserInputIsInt()
        {
            string validIntpattern = "^[0-9]+$";
            return Regex.IsMatch(userInput, validIntpattern);
        }
    }

}